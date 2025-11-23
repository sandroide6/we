using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data;

public class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }

    public DbSet<Proyecto> Proyectos => Set<Proyecto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Proyecto>().HasData(
            new Proyecto
            {
                Id = 1,
                Titulo = "E-Commerce Platform",
                Descripcion = "Plataforma de comercio electrónico con carrito de compras y gestión de inventario",
                ImagenUrl = "https://images.unsplash.com/photo-1460925895917-adf4198f6172?w=500&h=300&fit=crop",
                UrlProyecto = "https://github.com",
                Tecnologias = "C#, ASP.NET Core, React, SQL Server",
                FechaCreacion = new DateTime(2024, 1, 15)
            },
            new Proyecto
            {
                Id = 2,
                Titulo = "Task Management App",
                Descripcion = "Aplicación para gestionar tareas y proyectos con colaboración en tiempo real",
                ImagenUrl = "https://images.unsplash.com/photo-1454165804606-c3d57bc86b40?w=500&h=300&fit=crop",
                UrlProyecto = "https://github.com",
                Tecnologias = "Vue.js, Node.js, MongoDB, WebSocket",
                FechaCreacion = new DateTime(2024, 2, 20)
            },
            new Proyecto
            {
                Id = 3,
                Titulo = "Analytics Dashboard",
                Descripcion = "Dashboard de análisis de datos con visualizaciones interactivas",
                ImagenUrl = "https://images.unsplash.com/photo-1517694712202-14dd9538aa97?w=500&h=300&fit=crop",
                UrlProyecto = "https://github.com",
                Tecnologias = "Python, Flask, React, PostgreSQL, Chart.js",
                FechaCreacion = new DateTime(2024, 3, 10)
            }
        );
    }
}
