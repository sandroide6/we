using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using TechStore.Models;

namespace TechStore.Data;

public class TechStoreAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly TechStoreContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UsuarioService _usuarioService;

    public TechStoreAuthenticationStateProvider(
        TechStoreContext dbContext,
        IHttpContextAccessor httpContextAccessor,
        UsuarioService usuarioService)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _usuarioService = usuarioService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        
        if (httpContext?.User?.Identity?.IsAuthenticated == true)
        {
            var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(userId);
                if (usuario != null)
                {
                    _usuarioService.UsuarioActual = usuario;
                    _usuarioService.NotificarCambio();
                }
            }
            
            return new AuthenticationState(httpContext.User);
        }
        
        _usuarioService.UsuarioActual = null;
        _usuarioService.NotificarCambio();
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public void NotifyAuthenticationStateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
