namespace TechStore.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Contraseña { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Dirección { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = "https://ui-avatars.com/api/?name=Usuario&background=6366f1&color=fff&size=200";
    public string Ciudad { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public DateTime? UltimoLogin { get; set; }
    public bool EstaActivo { get; set; } = true;
    public List<Orden> Ordenes { get; set; } = new();
    public List<ProductoFavorito> ProductosFavoritos { get; set; } = new();
    
    public string NombreCompleto => $"{Nombre} {Apellido}".Trim();
    public decimal TotalGastado => Ordenes.Sum(o => o.PrecioTotal);
}
