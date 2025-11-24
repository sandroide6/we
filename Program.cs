using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Antiforgery;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<TechStoreContext>(options =>
    options.UseSqlite("Data Source=techstore.db"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "TechStore.Auth";
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.LoginPath = "/login";
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(sp =>
{
    var navigationManager = sp.GetRequiredService<NavigationManager>();
    return new HttpClient
    {
        BaseAddress = new Uri(navigationManager.BaseUri)
    };
});

builder.Services.AddScoped<CarritoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AuthenticationStateProvider, TechStoreAuthenticationStateProvider>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TechStoreContext>();
    db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapPost("/api/auth/login", async (LoginRequest request, UsuarioService usuarioService, HttpContext context, IAntiforgery antiforgery) =>
{
    await antiforgery.ValidateRequestAsync(context);
    var (exito, mensaje) = await usuarioService.LoginAsync(request.Email, request.Contraseña);
    return exito ? Results.Ok(new { success = true, message = mensaje }) 
                 : Results.BadRequest(new { success = false, message = mensaje });
});

app.MapPost("/api/auth/register", async (RegisterRequest request, UsuarioService usuarioService, HttpContext context, IAntiforgery antiforgery) =>
{
    await antiforgery.ValidateRequestAsync(context);
    var (exito, mensaje) = await usuarioService.RegistrarAsync(
        request.Email,
        request.Nombre,
        request.Apellido,
        request.Contraseña,
        request.ContraseñaConfirm
    );
    return exito ? Results.Ok(new { success = true, message = mensaje })
                 : Results.BadRequest(new { success = false, message = mensaje });
});

app.MapPost("/api/auth/logout", async (UsuarioService usuarioService, HttpContext context, IAntiforgery antiforgery) =>
{
    await antiforgery.ValidateRequestAsync(context);
    await usuarioService.LogoutAsync();
    return Results.Ok(new { success = true });
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run("http://0.0.0.0:5000");

public record LoginRequest(string Email, string Contraseña);
public record RegisterRequest(string Email, string Nombre, string Apellido, string Contraseña, string ContraseñaConfirm);
