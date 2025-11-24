namespace TechStore.Models;

public class ProductoFavorito
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public int ProductoTecnologicoId { get; set; }
    public ProductoTecnologico? ProductoTecnologico { get; set; }
    public DateTime FechaAgregado { get; set; } = DateTime.Now;
}
