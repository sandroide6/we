using TechStore.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TechStore.Data;

public class UsuarioService
{
    private readonly TechStoreContext _dbContext;
    public Usuario? UsuarioActual { get; set; }
    public event Action? OnUsuarioChanged;

    public UsuarioService(TechStoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(bool éxito, string mensaje)> RegistrarAsync(string email, string nombre, string apellido, string contraseña, string contraseñaConfirm)
    {
        if (contraseña != contraseñaConfirm)
            return (false, "Las contraseñas no coinciden");

        if (contraseña.Length < 6)
            return (false, "La contraseña debe tener al menos 6 caracteres");

        var usuarioExistente = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        if (usuarioExistente != null)
            return (false, "El email ya está registrado");

        var usuario = new Usuario
        {
            Email = email,
            Nombre = nombre,
            Apellido = apellido,
            Contraseña = HashContraseña(contraseña),
            FechaRegistro = DateTime.Now
        };

        _dbContext.Usuarios.Add(usuario);
        await _dbContext.SaveChangesAsync();

        UsuarioActual = usuario;
        NotifyUsuarioChanged();
        return (true, "Registro exitoso");
    }

    public async Task<(bool éxito, string mensaje)> LoginAsync(string email, string contraseña)
    {
        var usuario = await _dbContext.Usuarios
            .FirstOrDefaultAsync(u => u.Email == email && u.EstaActivo);

        if (usuario == null)
            return (false, "Email o contraseña incorrectos");

        if (!VerificaContraseña(contraseña, usuario.Contraseña))
            return (false, "Email o contraseña incorrectos");

        usuario.UltimoLogin = DateTime.Now;
        await _dbContext.SaveChangesAsync();

        UsuarioActual = usuario;
        NotifyUsuarioChanged();
        return (true, "Login exitoso");
    }

    public async Task LogoutAsync()
    {
        UsuarioActual = null;
        NotifyUsuarioChanged();
        await Task.CompletedTask;
    }

    public async Task<Usuario?> ObtenerUsuarioPorIdAsync(int id)
    {
        return await _dbContext.Usuarios
            .Include(u => u.Ordenes)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> ActualizarPerfilAsync(int id, string nombre, string apellido, string telefono, string dirección)
    {
        var usuario = await _dbContext.Usuarios.FindAsync(id);
        if (usuario == null)
            return false;

        usuario.Nombre = nombre;
        usuario.Apellido = apellido;
        usuario.Telefono = telefono;
        usuario.Dirección = dirección;

        await _dbContext.SaveChangesAsync();
        UsuarioActual = usuario;
        NotifyUsuarioChanged();
        return true;
    }

    private void NotifyUsuarioChanged()
    {
        OnUsuarioChanged?.Invoke();
    }

    public async Task<bool> CambiarContraseñaAsync(int id, string contraseñaActual, string contraseñaNueva, string contraseñaConfirm)
    {
        var usuario = await _dbContext.Usuarios.FindAsync(id);
        if (usuario == null)
            return false;

        if (!VerificaContraseña(contraseñaActual, usuario.Contraseña))
            return false;

        if (contraseñaNueva != contraseñaConfirm)
            return false;

        if (contraseñaNueva.Length < 6)
            return false;

        usuario.Contraseña = HashContraseña(contraseñaNueva);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    private string HashContraseña(string contraseña)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    private bool VerificaContraseña(string contraseña, string hash)
    {
        var hashDelInput = HashContraseña(contraseña);
        return hashDelInput == hash;
    }
}
