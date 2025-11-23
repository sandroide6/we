using TechStore.Models;

namespace TechStore.Data;

public class EstadoPedido
{
    public List<ItemOrden> Items { get; set; } = new();
    
    public event Action? OnCarritoActualizado;
    
    public void AgregarProducto(ProductoTecnologico producto)
    {
        var itemExistente = Items.FirstOrDefault(i => 
            i.ProductoTecnologicoId == producto.Id && 
            i.EspecificacionesSeleccionadas.Count == 0);
        
        if (itemExistente != null)
        {
            itemExistente.Cantidad++;
        }
        else
        {
            Items.Add(new ItemOrden
            {
                ProductoTecnologicoId = producto.Id,
                ProductoTecnologico = producto,
                Cantidad = 1,
                PrecioBaseProducto = producto.PrecioBase,
                EspecificacionesSeleccionadas = new List<EspecificacionOrden>()
            });
        }
        
        OnCarritoActualizado?.Invoke();
    }
    
    public void AgregarItem(ItemOrden item)
    {
        Items.Add(item);
        OnCarritoActualizado?.Invoke();
    }
    
    public void RemoverItem(ItemOrden item)
    {
        Items.Remove(item);
        OnCarritoActualizado?.Invoke();
    }
    
    public void LimpiarCarrito()
    {
        Items.Clear();
        OnCarritoActualizado?.Invoke();
    }
    
    public decimal PrecioTotal =>
        Items.Sum(i => i.PrecioTotal * i.Cantidad);
}
