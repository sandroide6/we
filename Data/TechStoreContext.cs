using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data;

public class TechStoreContext : DbContext
{
    public TechStoreContext(DbContextOptions<TechStoreContext> options)
        : base(options)
    {
    }

    public DbSet<ProductoTecnologico> ProductosTecnologicos { get; set; } = null!;
    public DbSet<Especificacion> Especificaciones { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Orden> Ordenes { get; set; } = null!;
    public DbSet<ItemOrden> ItemsOrden { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductoTecnologico>().HasData(
            new ProductoTecnologico
            {
                Id = 1,
                Nombre = "Laptop Dell XPS 15",
                Descripcion = "Laptop profesional de alto rendimiento con procesador Intel Core i7, ideal para desarrollo y diseño",
                PrecioBase = 1299.99m,
                ImagenUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=400",
                Tipo = TipoProducto.Hardware,
                Categoria = "Laptops"
            },
            new ProductoTecnologico
            {
                Id = 2,
                Nombre = "PC Gaming Gamer Pro",
                Descripcion = "Computador de escritorio potente con RTX 4070, ideal para gaming y renderizado 3D",
                PrecioBase = 1899.99m,
                ImagenUrl = "https://images.unsplash.com/photo-1587202372634-32705e3bf49c?w=400",
                Tipo = TipoProducto.Hardware,
                Categoria = "Computadores de Escritorio"
            },
            new ProductoTecnologico
            {
                Id = 3,
                Nombre = "Monitor LG UltraWide 34\"",
                Descripcion = "Monitor panorámico curvo 21:9, ideal para productividad y multitasking",
                PrecioBase = 599.99m,
                ImagenUrl = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=400",
                Tipo = TipoProducto.Hardware,
                Categoria = "Monitores"
            },
            new ProductoTecnologico
            {
                Id = 4,
                Nombre = "Microsoft Office 365 Business",
                Descripcion = "Suite completa de productividad con Word, Excel, PowerPoint, Teams y más",
                PrecioBase = 149.99m,
                ImagenUrl = "https://images.unsplash.com/photo-1633419461186-7d40a38105ec?w=400",
                Tipo = TipoProducto.Software,
                Categoria = "Suites de Oficina"
            },
            new ProductoTecnologico
            {
                Id = 5,
                Nombre = "Windows 11 Pro",
                Descripcion = "Sistema operativo profesional con características avanzadas de seguridad",
                PrecioBase = 199.99m,
                ImagenUrl = "https://images.unsplash.com/photo-1633419461186-7d40a38105ec?w=400",
                Tipo = TipoProducto.Software,
                Categoria = "Sistemas Operativos"
            },
            new ProductoTecnologico
            {
                Id = 6,
                Nombre = "Adobe Creative Cloud",
                Descripcion = "Acceso completo a todas las aplicaciones de Adobe: Photoshop, Illustrator, Premiere Pro y más",
                PrecioBase = 599.99m,
                ImagenUrl = "https://images.unsplash.com/photo-1626785774573-4b799315345d?w=400",
                Tipo = TipoProducto.Software,
                Categoria = "Software de Diseño"
            },
            new ProductoTecnologico
            {
                Id = 7,
                Nombre = "Soporte Técnico Premium",
                Descripcion = "Soporte técnico 24/7 con técnicos especializados para tu negocio",
                PrecioBase = 299.99m,
                ImagenUrl = "https://images.unsplash.com/photo-1573164713714-d95e436ab8d6?w=400",
                Tipo = TipoProducto.Servicio,
                Categoria = "Servicios TI"
            },
            new ProductoTecnologico
            {
                Id = 8,
                Nombre = "Desarrollo de Software a Medida",
                Descripcion = "Desarrollo personalizado de aplicaciones empresariales según tus necesidades",
                PrecioBase = 4999.99m,
                ImagenUrl = "https://images.unsplash.com/photo-1555066931-4365d14bab8c?w=400",
                Tipo = TipoProducto.Servicio,
                Categoria = "Servicios TI"
            }
        );

        modelBuilder.Entity<Especificacion>().HasData(
            new Especificacion { Id = 1, Nombre = "RAM 32GB (upgrade)", PrecioAdicional = 200m, ProductoTecnologicoId = 1 },
            new Especificacion { Id = 2, Nombre = "SSD 1TB (upgrade)", PrecioAdicional = 150m, ProductoTecnologicoId = 1 },
            new Especificacion { Id = 3, Nombre = "Garantía extendida 3 años", PrecioAdicional = 99m, ProductoTecnologicoId = 1 },
            
            new Especificacion { Id = 4, Nombre = "RAM 64GB (upgrade)", PrecioAdicional = 400m, ProductoTecnologicoId = 2 },
            new Especificacion { Id = 5, Nombre = "SSD 2TB NVMe (upgrade)", PrecioAdicional = 300m, ProductoTecnologicoId = 2 },
            new Especificacion { Id = 6, Nombre = "RTX 4080 (upgrade)", PrecioAdicional = 500m, ProductoTecnologicoId = 2 },
            
            new Especificacion { Id = 7, Nombre = "Brazo monitor ergonómico", PrecioAdicional = 79m, ProductoTecnologicoId = 3 },
            new Especificacion { Id = 8, Nombre = "Calibración profesional", PrecioAdicional = 149m, ProductoTecnologicoId = 3 },
            
            new Especificacion { Id = 9, Nombre = "Licencias adicionales (x5)", PrecioAdicional = 500m, ProductoTecnologicoId = 4 },
            new Especificacion { Id = 10, Nombre = "Soporte prioritario", PrecioAdicional = 99m, ProductoTecnologicoId = 4 },
            
            new Especificacion { Id = 11, Nombre = "Instalación y configuración", PrecioAdicional = 49m, ProductoTecnologicoId = 5 },
            
            new Especificacion { Id = 12, Nombre = "Plan anual (descuento 20%)", PrecioAdicional = -120m, ProductoTecnologicoId = 6 },
            
            new Especificacion { Id = 13, Nombre = "Visitas on-site incluidas", PrecioAdicional = 199m, ProductoTecnologicoId = 7 },
            
            new Especificacion { Id = 14, Nombre = "Mantenimiento 1 año incluido", PrecioAdicional = 999m, ProductoTecnologicoId = 8 }
        );
    }
}
