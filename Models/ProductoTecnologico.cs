namespace TechStore.Models;

public class ProductoTecnologico
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public decimal PrecioBase { get; set; }
    public string ImagenUrl { get; set; } = string.Empty;
    public TipoProducto Tipo { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public List<Especificacion> EspecificacionesDisponibles { get; set; } = new();
}

public enum TipoProducto
{
    Hardware,
    Software,
    Servicio
}
