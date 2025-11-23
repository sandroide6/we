namespace TechStore.Models;

public class Orden
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public string DireccionEntrega { get; set; } = string.Empty;
    public string NombreCliente { get; set; } = string.Empty;
    public string EmailCliente { get; set; } = string.Empty;
    public int? UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public List<ItemOrden> Items { get; set; } = new();
    
    public decimal PrecioTotal =>
        Items.Sum(i => i.PrecioTotal);
}
