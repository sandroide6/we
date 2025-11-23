using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<TechStoreContext>(options =>
    options.UseSqlite("Data Source=techstore.db"));

builder.Services.AddScoped<EstadoPedido>();
builder.Services.AddSingleton<UsuarioService>();

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
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run("http://0.0.0.0:5000");
