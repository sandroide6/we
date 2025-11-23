namespace TechStore.Models;

public class EspecificacionOrden
{
    public int Id { get; set; }
    public int EspecificacionId { get; set; }
    public Especificacion? Especificacion { get; set; }
    public decimal PrecioEspecificacion { get; set; }
}
