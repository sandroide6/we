namespace TechStore.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Contraseña { get; set; } = string.Empty;  // Hash en producción
    public string Telefono { get; set; } = string.Empty;
    public string Dirección { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public DateTime? UltimoLogin { get; set; }
    public bool EstaActivo { get; set; } = true;
    public List<Orden> Ordenes { get; set; } = new();
}
