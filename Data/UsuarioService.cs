using TechStore.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TechStore.Data;

public class UsuarioService
{
    private readonly TechStoreContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public Usuario? UsuarioActual { get; set; }
    public event Action? OnChange;

    public UsuarioService(TechStoreContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public void NotificarCambio()
    {
        OnChange?.Invoke();
    }

    public async Task<(bool éxito, string mensaje)> RegistrarAsync(string email, string nombre, string apellido, string contraseña, string contraseñaConfirm)
    {
        if (string.IsNullOrWhiteSpace(email))
            return (false, "El email es requerido");

        if (string.IsNullOrWhiteSpace(nombre))
            return (false, "El nombre es requerido");

        if (string.IsNullOrWhiteSpace(apellido))
            return (false, "El apellido es requerido");

        if (!EsEmailValido(email))
            return (false, "El formato del email no es válido");

        if (contraseña != contraseñaConfirm)
            return (false, "Las contraseñas no coinciden");

        if (contraseña.Length < 8)
            return (false, "La contraseña debe tener al menos 8 caracteres");

        if (!TieneContraseñaSegura(contraseña))
            return (false, "La contraseña debe contener al menos una mayúscula, una minúscula y un número");

        var usuarioExistente = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        if (usuarioExistente != null)
            return (false, "El email ya está registrado");

        var avatarUrl = $"https://ui-avatars.com/api/?name={Uri.EscapeDataString(nombre + " " + apellido)}&background=6366f1&color=fff&size=200";

        var usuario = new Usuario
        {
            Email = email.ToLower(),
            Nombre = nombre.Trim(),
            Apellido = apellido.Trim(),
            Contraseña = HashContraseña(contraseña),
            AvatarUrl = avatarUrl,
            FechaRegistro = DateTime.Now
        };

        _dbContext.Usuarios.Add(usuario);
        await _dbContext.SaveChangesAsync();

        UsuarioActual = usuario;
        await IniciarSesionCookieAsync(usuario);
        NotificarCambio();
        return (true, "¡Cuenta creada exitosamente!");
    }

    public async Task<(bool éxito, string mensaje)> LoginAsync(string email, string contraseña)
    {
        if (string.IsNullOrWhiteSpace(email))
            return (false, "El email es requerido");

        if (string.IsNullOrWhiteSpace(contraseña))
            return (false, "La contraseña es requerida");

        var usuario = await _dbContext.Usuarios
            .Include(u => u.ProductosFavoritos)
            .Include(u => u.Ordenes)
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.EstaActivo);

        if (usuario == null)
            return (false, "Email o contraseña incorrectos");

        if (!VerificaContraseña(contraseña, usuario.Contraseña))
            return (false, "Email o contraseña incorrectos");

        usuario.UltimoLogin = DateTime.Now;
        await _dbContext.SaveChangesAsync();

        UsuarioActual = usuario;
        await IniciarSesionCookieAsync(usuario);
        NotificarCambio();
        return (true, "¡Bienvenido de vuelta!");
    }

    public async Task LogoutAsync()
    {
        UsuarioActual = null;
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext != null)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        NotificarCambio();
    }

    private async Task IniciarSesionCookieAsync(Usuario usuario)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
            return;

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.NombreCompleto),
            new Claim(ClaimTypes.Email, usuario.Email)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
        };

        await httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
    }

    private bool EsEmailValido(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private bool TieneContraseñaSegura(string contraseña)
    {
        return contraseña.Any(char.IsUpper) &&
               contraseña.Any(char.IsLower) &&
               contraseña.Any(char.IsDigit);
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

        if (contraseñaNueva.Length < 8)
            return false;

        if (!TieneContraseñaSegura(contraseñaNueva))
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
}
