namespace TechStore.Models;

public class Especificacion
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal PrecioAdicional { get; set; }
    public int ProductoTecnologicoId { get; set; }
    public ProductoTecnologico? ProductoTecnologico { get; set; }
}
