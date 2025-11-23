using TechStore.Models;
using System.Text.Json;
using Microsoft.JSInterop;

namespace TechStore.Data;

public class CarritoService
{
    private const string CarroStorageKey = "techstore_carro";
    private readonly IJSRuntime _js;
    
    public CarritoService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<List<ItemOrden>> ObtenerItems()
    {
        try
        {
            var json = await _js.InvokeAsync<string>("sessionStorage.getItem", CarroStorageKey);
            if (string.IsNullOrEmpty(json))
                return new List<ItemOrden>();
            
            return JsonSerializer.Deserialize<List<ItemOrden>>(json) ?? new List<ItemOrden>();
        }
        catch
        {
            return new List<ItemOrden>();
        }
    }

    public async Task AgregarProducto(ProductoTecnologico producto)
    {
        var items = await ObtenerItems();
        var existente = items.FirstOrDefault(i => 
            i.ProductoTecnologicoId == producto.Id && 
            i.EspecificacionesSeleccionadas.Count == 0);

        if (existente != null)
        {
            existente.Cantidad++;
        }
        else
        {
            items.Add(new ItemOrden
            {
                ProductoTecnologicoId = producto.Id,
                ProductoTecnologico = producto,
                Cantidad = 1,
                PrecioBaseProducto = producto.PrecioBase,
                EspecificacionesSeleccionadas = new()
            });
        }

        await GuardarItems(items);
    }

    public async Task AgregarItem(ItemOrden item)
    {
        var items = await ObtenerItems();
        items.Add(item);
        await GuardarItems(items);
    }

    public async Task RemoverItem(ItemOrden item)
    {
        var items = await ObtenerItems();
        var itemARemover = items.FirstOrDefault(i => i.Id == item.Id);
        if (itemARemover != null)
        {
            items.Remove(itemARemover);
            await GuardarItems(items);
        }
    }

    public async Task LimpiarCarrito()
    {
        await _js.InvokeVoidAsync("sessionStorage.removeItem", CarroStorageKey);
    }

    public async Task<decimal> ObtenerTotal(TechStoreContext dbContext)
    {
        var items = await ObtenerItems();
        return items.Sum(i => i.PrecioTotal * i.Cantidad);
    }

    private async Task GuardarItems(List<ItemOrden> items)
    {
        var json = JsonSerializer.Serialize(items);
        await _js.InvokeVoidAsync("sessionStorage.setItem", CarroStorageKey, json);
    }
}
