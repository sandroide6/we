namespace TechStore.Models;

public class ItemOrden
{
    public int Id { get; set; }
    public int ProductoTecnologicoId { get; set; }
    public ProductoTecnologico? ProductoTecnologico { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioBaseProducto { get; set; }
    public List<EspecificacionOrden> EspecificacionesSeleccionadas { get; set; } = new();
    
    public decimal PrecioTotal =>
        PrecioBaseProducto + EspecificacionesSeleccionadas.Sum(e => e.PrecioEspecificacion);
}
