using TechStore.Models;

namespace TechStore.Data;

public class EstadoPedido
{
    public event Action? OnChange;
    
    public List<ItemOrden> Items { get; set; } = new();
    
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
        NotificarCambio();
    }
    
    public void AgregarItem(ItemOrden item)
    {
        Items.Add(item);
        NotificarCambio();
    }
    
    public void RemoverItem(ItemOrden item)
    {
        Items.Remove(item);
        NotificarCambio();
    }
    
    public void ActualizarCantidad(ItemOrden item, int nuevaCantidad)
    {
        if (nuevaCantidad <= 0)
        {
            RemoverItem(item);
        }
        else
        {
            item.Cantidad = nuevaCantidad;
            NotificarCambio();
        }
    }
    
    public void LimpiarCarrito()
    {
        Items.Clear();
        NotificarCambio();
    }
    
    public decimal PrecioTotal =>
        Items.Sum(i => i.PrecioTotal * i.Cantidad);
    
    private void NotificarCambio()
    {
        OnChange?.Invoke();
    }
}
