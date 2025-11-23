namespace TechStore.Models;

public class CarritoItemDTO
{
    public int ProductoTecnologicoId { get; set; }
    public string? ProductoNombre { get; set; }
    public string? ProductoImagen { get; set; }
    public decimal PrecioBaseProducto { get; set; }
    public int Cantidad { get; set; }
    public List<EspecificacionCarritoDTO> Especificaciones { get; set; } = new();

    public decimal PrecioTotal =>
        PrecioBaseProducto + Especificaciones.Sum(e => e.Precio);
}

public class EspecificacionCarritoDTO
{
    public int EspecificacionId { get; set; }
    public string? Nombre { get; set; }
    public decimal Precio { get; set; }
}
