using TechStore.Models;

namespace TechStore.Data;

public class CarritoService
{
    private List<ItemOrden> items = new();
    public event Action? OnChange;

    public IReadOnlyList<ItemOrden> Items => items.AsReadOnly();
    
    public int CantidadTotal => items.Sum(i => i.Cantidad);
    
    public decimal PrecioTotal => items.Sum(i => i.PrecioTotal * i.Cantidad);

    public void AgregarProducto(ProductoTecnologico producto)
    {
        var itemExistente = items.FirstOrDefault(i => 
            i.ProductoTecnologicoId == producto.Id && 
            !i.EspecificacionesSeleccionadas.Any());

        if (itemExistente != null)
        {
            itemExistente.Cantidad++;
        }
        else
        {
            items.Add(new ItemOrden
            {
                ProductoTecnologicoId = producto.Id,
                ProductoTecnologico = producto,
                Cantidad = 1,
                PrecioBaseProducto = producto.PrecioBase
            });
        }
        
        NotificarCambio();
    }

    public void AgregarItem(ItemOrden item)
    {
        var especIds = string.Join(",", item.EspecificacionesSeleccionadas
            .Select(e => e.EspecificacionId)
            .OrderBy(id => id));
        
        var itemExistente = items.FirstOrDefault(i => 
            i.ProductoTecnologicoId == item.ProductoTecnologicoId &&
            string.Join(",", i.EspecificacionesSeleccionadas
                .Select(e => e.EspecificacionId)
                .OrderBy(id => id)) == especIds);

        if (itemExistente != null)
        {
            itemExistente.Cantidad++;
        }
        else
        {
            items.Add(item);
        }
        
        NotificarCambio();
    }

    public void RemoverItem(ItemOrden item)
    {
        items.Remove(item);
        NotificarCambio();
    }

    public void ActualizarCantidad(ItemOrden item, int cantidad)
    {
        if (cantidad <= 0)
        {
            RemoverItem(item);
        }
        else
        {
            item.Cantidad = cantidad;
            NotificarCambio();
        }
    }

    public void LimpiarCarrito()
    {
        items.Clear();
        NotificarCambio();
    }

    public bool EstaVacio() => !items.Any();

    private void NotificarCambio()
    {
        OnChange?.Invoke();
    }
}
