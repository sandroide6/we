using TechStore.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace TechStore.Data;

public class UsuarioService
{
    private readonly TechStoreContext _dbContext;
    public Usuario? UsuarioActual { get; set; }
    public event Action? OnChange;

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

        var avatarUrl = $"https://ui-avatars.com/api/?name={Uri.EscapeDataString(nombre + " " + apellido)}&background=6366f1&color=fff&size=200";

        var usuario = new Usuario
        {
            Email = email,
            Nombre = nombre,
            Apellido = apellido,
            Contraseña = HashContraseña(contraseña),
            AvatarUrl = avatarUrl,
            FechaRegistro = DateTime.Now
        };

        _dbContext.Usuarios.Add(usuario);
        await _dbContext.SaveChangesAsync();

        UsuarioActual = usuario;
        NotificarCambio();
        return (true, "Registro exitoso");
    }

    public async Task<(bool éxito, string mensaje)> LoginAsync(string email, string contraseña)
    {
        var usuario = await _dbContext.Usuarios
            .Include(u => u.ProductosFavoritos)
            .FirstOrDefaultAsync(u => u.Email == email && u.EstaActivo);

        if (usuario == null)
            return (false, "Email o contraseña incorrectos");

        if (!VerificaContraseña(contraseña, usuario.Contraseña))
            return (false, "Email o contraseña incorrectos");

        usuario.UltimoLogin = DateTime.Now;
        await _dbContext.SaveChangesAsync();

        UsuarioActual = usuario;
        NotificarCambio();
        return (true, "Login exitoso");
    }

    public async Task LogoutAsync()
    {
        UsuarioActual = null;
        NotificarCambio();
        await Task.CompletedTask;
    }

    public async Task<Usuario?> ObtenerUsuarioPorIdAsync(int id)
    {
        return await _dbContext.Usuarios
            .Include(u => u.Ordenes)
                .ThenInclude(o => o.Items)
                    .ThenInclude(i => i.ProductoTecnologico)
            .Include(u => u.ProductosFavoritos)
                .ThenInclude(f => f.ProductoTecnologico)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> ActualizarPerfilAsync(int id, string nombre, string apellido, string telefono, string dirección, string ciudad, string pais)
    {
        var usuario = await _dbContext.Usuarios.FindAsync(id);
        if (usuario == null)
            return false;

        usuario.Nombre = nombre;
        usuario.Apellido = apellido;
        usuario.Telefono = telefono;
        usuario.Dirección = dirección;
        usuario.Ciudad = ciudad;
        usuario.Pais = pais;

        var nuevoAvatarUrl = $"https://ui-avatars.com/api/?name={Uri.EscapeDataString(nombre + " " + apellido)}&background=6366f1&color=fff&size=200";
        usuario.AvatarUrl = nuevoAvatarUrl;

        await _dbContext.SaveChangesAsync();
        UsuarioActual = usuario;
        NotificarCambio();
        return true;
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

    public async Task<bool> AgregarAFavoritosAsync(int usuarioId, int productoId)
    {
        var yaExiste = await _dbContext.ProductosFavoritos
            .AnyAsync(f => f.UsuarioId == usuarioId && f.ProductoTecnologicoId == productoId);

        if (yaExiste)
            return false;

        var favorito = new ProductoFavorito
        {
            UsuarioId = usuarioId,
            ProductoTecnologicoId = productoId,
            FechaAgregado = DateTime.Now
        };

        _dbContext.ProductosFavoritos.Add(favorito);
        await _dbContext.SaveChangesAsync();

        if (UsuarioActual != null)
        {
            UsuarioActual = await ObtenerUsuarioPorIdAsync(usuarioId);
        }

        NotificarCambio();
        return true;
    }

    public async Task<bool> RemoverDeFavoritosAsync(int usuarioId, int productoId)
    {
        var favorito = await _dbContext.ProductosFavoritos
            .FirstOrDefaultAsync(f => f.UsuarioId == usuarioId && f.ProductoTecnologicoId == productoId);

        if (favorito == null)
            return false;

        _dbContext.ProductosFavoritos.Remove(favorito);
        await _dbContext.SaveChangesAsync();

        if (UsuarioActual != null)
        {
            UsuarioActual = await ObtenerUsuarioPorIdAsync(usuarioId);
        }

        NotificarCambio();
        return true;
    }

    public async Task<bool> EsFavoritoAsync(int usuarioId, int productoId)
    {
        return await _dbContext.ProductosFavoritos
            .AnyAsync(f => f.UsuarioId == usuarioId && f.ProductoTecnologicoId == productoId);
    }

    public async Task<List<ProductoTecnologico>> ObtenerFavoritosAsync(int usuarioId)
    {
        return await _dbContext.ProductosFavoritos
            .Where(f => f.UsuarioId == usuarioId)
            .Include(f => f.ProductoTecnologico)
                .ThenInclude(p => p!.EspecificacionesDisponibles)
            .Select(f => f.ProductoTecnologico!)
            .ToListAsync();
    }

    private string HashContraseña(string contraseña)
    {
        return BCrypt.Net.BCrypt.HashPassword(contraseña, workFactor: 12);
    }

    private bool VerificaContraseña(string contraseña, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(contraseña, hash);
    }

    private void NotificarCambio()
    {
        OnChange?.Invoke();
    }
}
