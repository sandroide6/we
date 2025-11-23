# 🚀 TechStore - Tienda de Tecnología Moderna

![TechStore Banner](https://img.shields.io/badge/ASP.NET%20Core-8.0-blue?logo=dotnet) ![Blazor Server](https://img.shields.io/badge/Blazor-Server-purple?logo=blazor) ![License](https://img.shields.io/badge/License-MIT-green) ![Status](https://img.shields.io/badge/Status-Production%20Ready-brightgreen)

**Una tienda de tecnología moderna y profesional construida con ASP.NET Core 8.0 Blazor Server.**

---

## 📑 Tabla de Contenidos

1. [Descripción General](#descripción-general)
2. [Características Principales](#características-principales)
3. [Instalación y Setup](#instalación-y-setup)
4. [Cómo Usar la Aplicación](#cómo-usar-la-aplicación)
5. [Modelos de Datos](#modelos-de-datos)
6. [Flujo de Datos](#flujo-de-datos)
7. [Estructura del Proyecto](#estructura-del-proyecto)
8. [API y Servicios](#api-y-servicios)
9. [Cambios Realizados](#cambios-realizados-respecto-al-original)
10. [Configuración](#configuración)
11. [Solución de Problemas](#solución-de-problemas)
12. [Roadmap Futuro](#roadmap-futuro)
13. [Créditos](#créditos)

---

## 📱 Descripción General

**TechStore** es una aplicación web de comercio electrónico especializada en productos tecnológicos. Permite a los usuarios:

- ✅ **Explorar** un catálogo de 8+ productos tecnológicos
- ✅ **Personalizar** productos con especificaciones adicionales (upgrades, garantías, etc.)
- ✅ **Gestionar** un carrito de compras interactivo
- ✅ **Realizar** pedidos completos con datos de cliente
- ✅ **Visualizar** historial de todas las órdenes realizadas

### 🎯 Objetivo

Proporcionar una plataforma moderna y profesional para la venta de tecnología, con una experiencia de usuario fluida, intuitiva y visualmente atractiva.

### 💡 Tecnologías Utilizadas

- **Backend**: ASP.NET Core 8.0
- **Frontend**: Blazor Server (Razor Components)
- **Database**: SQLite con Entity Framework Core 8.0
- **UI/UX**: CSS personalizado con tema oscuro
- **Lenguaje**: C# 12
- **Tipografía**: Google Fonts (Inter)
- **Imágenes**: Unsplash

---

## ✨ Características Principales

### 🛒 Catálogo Interactivo

- **8 Productos Tecnológicos** listos para vender
- **Filtros por Categoría**:
  - 💻 Hardware (laptops, PCs, monitores)
  - 📦 Software (licencias, sistemas operativos)
  - 🛠️ Servicios TI (soporte, desarrollo)
- **Tarjetas de Productos** con:
  - Imagen de alta calidad
  - Nombre y descripción detallada
  - Precio base
  - Tipo de producto

### 🎨 Personalización Avanzada

- **Modal de Personalización** que permite:
  - Seleccionar múltiples especificaciones
  - Ver precio actualizado en tiempo real
  - Vista previa completa antes de agregar
- **14 Especificaciones Disponibles**:
  - Upgrades de hardware (RAM, SSD, GPU)
  - Licencias adicionales
  - Servicios extra
  - **Descuentos** (especificaciones con precio negativo)

### 🛍️ Carrito de Compras Inteligente

- **Resumen en Tiempo Real**:
  - Cantidad de items
  - Total de la compra
  - Visible en el header
- **Gestión de Items**:
  - Modificar cantidades
  - Eliminar productos
  - Ver detalles de especificaciones

### 📦 Sistema Completo de Pedidos

**Flujo de Checkout:**
1. Revisa los productos en el carrito
2. Completa información del cliente (nombre, email, dirección)
3. Valida el formulario automáticamente
4. Confirma y realiza el pedido
5. Se guarda en la base de datos automáticamente

**Historial de Órdenes:**
- Visualiza todas tus órdenes realizadas
- Vuelve a ver los detalles de cualquier pedido anterior
- Consulta fecha, cliente, dirección, productos y especificaciones

### 🎨 Diseño Moderno y Profesional

- **Tema Oscuro Tecnológico**:
  - Colores: Cyan (#06b6d4), Púrpura (#8b5cf6), Negro profundo (#0f172a)
  - Gradientes y efectos visuales modernos
- **Animaciones Fluidas**:
  - Transiciones suaves
  - Efectos hover interactivos
  - Escala y sombras dinámicas
- **Responsive Design**:
  - Funciona perfectamente en móviles
  - Tablet
  - Desktop

---

## 🚀 Instalación y Setup

### Requisitos Previos

- **.NET 8.0 SDK** instalado ([descargar](https://dotnet.microsoft.com/download))
- Un navegador web moderno (Chrome, Firefox, Edge, Safari)
- 500MB de espacio libre en disco

### Paso 1: Clonar el Repositorio

```bash
git clone https://github.com/tuusuario/TechStore.git
cd TechStore
```

### Paso 2: Restaurar Dependencias

```bash
dotnet restore
```

### Paso 3: Crear la Base de Datos

```bash
# Opcional: Eliminar DB anterior si existe
rm -f techstore.db

# La DB se crea automáticamente con datos de ejemplo al iniciar
```

### Paso 4: Ejecutar la Aplicación

```bash
dotnet run
```

La aplicación estará disponible en: **http://localhost:5000**

### Verificación de Instalación

- ✅ Página de inicio carga correctamente
- ✅ Ves 8 productos tecnológicos
- ✅ Puedes hacer clic en "Personalizar"
- ✅ El carrito funciona en tiempo real

---

## 📖 Cómo Usar la Aplicación

### 1️⃣ Explorar el Catálogo

```
1. Abre http://localhost:5000 en tu navegador
2. Ves el catálogo de productos con 8 artículos
3. Usa los filtros de categoría:
   - "Todos los Productos" (muestra los 8)
   - "💻 Hardware" (3 productos)
   - "📦 Software" (3 productos)
   - "🛠️ Servicios TI" (2 productos)
4. Lee las descripciones de cada producto
5. Nota los precios base
```

### 2️⃣ Personalizar un Producto

```
1. Haz clic en "Personalizar" en cualquier producto
2. Se abre un modal con:
   - Imagen del producto
   - Nombre y descripción
   - Precio base
   - Lista de especificaciones disponibles
3. Selecciona las especificaciones que desees:
   - Marca el checkbox de la especificación
   - Ver el precio actualizado automáticamente
   - Nota: algunos items tienen descuentos (precio negativo)
4. Revisa el total en la sección "Total"
5. Haz clic en "Agregar al Carrito"
6. El modal se cierra automáticamente
```

**Ejemplo de Personalización:**
```
Producto: PC Gaming Gamer Pro ($1,899.99)
Especificaciones seleccionadas:
  ✓ RAM 64GB (upgrade)        +$400.00
  ✓ SSD 2TB NVMe (upgrade)    +$300.00
  ✓ RTX 4080 (upgrade)        +$500.00
                       Total: $3,099.99
```

### 3️⃣ Agregar Productos Simples

```
1. Para productos sin especificaciones (algunos software)
2. Haz clic en "Agregar" directamente
3. Se agrega al carrito inmediatamente
4. La cantidad en el carrito aumenta en el header
```

### 4️⃣ Gestionar el Carrito

```
1. En el header, ves el resumen del carrito:
   - Icono: 🛒
   - Cantidad de items (número en la esquina)
   - Total en dinero

2. Haz clic en el carrito para ir a la página de checkout

3. En checkout, puedes:
   - Ver todos los productos agregados
   - Ver la imagen, nombre, tipo y especificaciones
   - Modificar las cantidades (cambiar el número)
   - Eliminar items (botón "Eliminar" rojo)
```

### 5️⃣ Realizar un Pedido

```
1. En la página de Checkout, completa el formulario:
   
   Nombre Completo: Juan Pérez
   Email: juan@example.com
   Dirección: Calle Principal 123, Ciudad, País

2. Revisa el resumen del pedido:
   - Subtotal: (suma de todos los items)
   - Envío: GRATIS
   - Total: (monto final)

3. Haz clic en "✓ Confirmar Pedido"
   - El botón cambia a "Procesando..."
   - Tu pedido se guarda en la base de datos
   - Se te redirige a "Mis Pedidos"

4. ¡Listo! Tu pedido fue confirmado
```

### 6️⃣ Ver Historial de Pedidos

```
1. Haz clic en "Mis Pedidos" en el menú principal
2. Ves una lista de todos tus pedidos realizados
3. Para cada pedido, ves:
   - Número de pedido (ID)
   - Fecha y hora exacta
   - Estado: "✓ Confirmado"
   - Información del cliente:
     * Nombre completo
     * Email
     * Dirección de entrega
   - Productos incluidos:
     * Nombre del producto
     * Cantidad
     * Especificaciones seleccionadas (en tags)
     * Precio total
   - Total del pedido

4. Los pedidos se muestran ordenados por fecha (más recientes primero)
```

---

## 🗄️ Modelos de Datos

### 1. ProductoTecnologico

Representa cada producto en la tienda.

```csharp
public class ProductoTecnologico
{
    public int Id { get; set; }
    public string Nombre { get; set; }                    // "Laptop Dell XPS 15"
    public string Descripcion { get; set; }              // Descripción detallada
    public decimal PrecioBase { get; set; }              // 1299.99
    public string ImagenUrl { get; set; }                // URL de imagen
    public TipoProducto Tipo { get; set; }               // Hardware/Software/Servicio
    public string Categoria { get; set; }                // "Laptops", "Suites de Oficina"
    public List<Especificacion> 
        EspecificacionesDisponibles { get; set; }        // Upgrades disponibles
}

public enum TipoProducto
{
    Hardware = 0,   // Computadores, periféricos
    Software = 1,   // Licencias, sistemas
    Servicio = 2    // Soporte, desarrollo
}
```

**Ejemplo de Datos:**
```json
{
  "id": 1,
  "nombre": "Laptop Dell XPS 15",
  "descripcion": "Laptop profesional de alto rendimiento...",
  "precioBase": 1299.99,
  "imagenUrl": "https://images.unsplash.com/...",
  "tipo": 0,
  "categoria": "Laptops",
  "especificacionesDisponibles": [...]
}
```

### 2. Especificacion

Extras/upgrades que se pueden agregar a los productos.

```csharp
public class Especificacion
{
    public int Id { get; set; }
    public string Nombre { get; set; }                   // "RAM 32GB (upgrade)"
    public decimal PrecioAdicional { get; set; }         // 200.00 (puede ser negativo)
    public int ProductoTecnologicoId { get; set; }       // FK al producto
    public ProductoTecnologico? ProductoTecnologico { get; set; }
}
```

**Ejemplos:**
```csharp
// Upgrade (positivo)
new Especificacion { Nombre = "RAM 32GB", PrecioAdicional = 200m }

// Descuento (negativo)
new Especificacion { Nombre = "Plan anual (-20%)", PrecioAdicional = -120m }

// Servicio extra
new Especificacion { Nombre = "Garantía extendida", PrecioAdicional = 99m }
```

### 3. Orden

Representa un pedido completo realizado por un cliente.

```csharp
public class Orden
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; }          // 2025-11-23 19:45:32
    public string DireccionEntrega { get; set; }        // "Calle 123, Ciudad"
    public string NombreCliente { get; set; }            // "Juan Pérez"
    public string EmailCliente { get; set; }             // "juan@example.com"
    public List<ItemOrden> Items { get; set; }           // Productos en la orden
    
    // Propiedad calculada
    public decimal PrecioTotal => Items.Sum(i => i.PrecioTotal);
}
```

**Ejemplo:**
```csharp
var orden = new Orden
{
    Id = 1,
    FechaCreacion = DateTime.Now,
    NombreCliente = "Juan Pérez",
    EmailCliente = "juan@example.com",
    DireccionEntrega = "Calle Principal 123, Madrid, España",
    Items = [...]
};
```

### 4. ItemOrden

Un producto específico dentro de una orden (puede estar personalizado).

```csharp
public class ItemOrden
{
    public int Id { get; set; }
    public int ProductoTecnologicoId { get; set; }       // FK al producto
    public ProductoTecnologico? ProductoTecnologico { get; set; }
    public int Cantidad { get; set; }                    // 2 unidades
    public decimal PrecioBaseProducto { get; set; }      // Precio guardado
    public List<EspecificacionOrden> 
        EspecificacionesSeleccionadas { get; set; }      // Especificaciones
    
    // Propiedad calculada (precio sin cantidad)
    public decimal PrecioTotal =>
        PrecioBaseProducto + EspecificacionesSeleccionadas
            .Sum(e => e.PrecioEspecificacion);
}
```

**Ejemplo:**
```csharp
var item = new ItemOrden
{
    ProductoTecnologicoId = 1,
    Cantidad = 1,
    PrecioBaseProducto = 1299.99m,
    EspecificacionesSeleccionadas = [
        new EspecificacionOrden { 
            EspecificacionId = 1, 
            PrecioEspecificacion = 200m 
        }
    ]
    // PrecioTotal = 1299.99 + 200 = 1499.99
};
```

### 5. EspecificacionOrden

Una especificación seleccionada dentro de un item (histórico de precio).

```csharp
public class EspecificacionOrden
{
    public int Id { get; set; }
    public int EspecificacionId { get; set; }            // FK a especificación
    public Especificacion? Especificacion { get; set; }
    public decimal PrecioEspecificacion { get; set; }    // Precio al momento de compra
}
```

**Ejemplo:**
```csharp
new EspecificacionOrden
{
    EspecificacionId = 1,
    Especificacion = especificacionDb,  // Referencia completa
    PrecioEspecificacion = 200m         // Precio guardado
}
```

---

## 🔄 Flujo de Datos

### 1. Cargar Catálogo (Página Index)

```
Usuario abre http://localhost:5000
                    ↓
        IndexPage se inicializa
                    ↓
    DbContext carga ProductosTecnologicos
       con Include(Especificaciones)
                    ↓
    Se genera Grid de 8 productos
                    ↓
Usuario ve catálogo filtrable
```

### 2. Personalizar Producto

```
Usuario hace clic "Personalizar"
                    ↓
    Modal se abre con producto
       y todas sus especificaciones
                    ↓
Usuario marca checkboxes
                    ↓
Precio se calcula en tiempo real:
  Total = PrecioBase + 
          Σ(EspecificacionesSeleccionadas)
                    ↓
Usuario haz clic "Agregar al Carrito"
                    ↓
ItemOrden se crea con:
  - ProductoTecnologicoId
  - EspecificacionesSeleccionadas[]
  - Cantidad = 1
                    ↓
Item se agrega a EstadoPedido.Items
                    ↓
Modal se cierra, contador del carrito ++
```

### 3. Realizar Pedido (Flujo Completo)

```
Usuario hace clic en carrito
                    ↓
    Llega a página Checkout
                    ↓
Ve todos los ItemsOrden en el carrito
                    ↓
Puede modificar cantidades o eliminar
                    ↓
Completa formulario:
  - Nombre cliente
  - Email
  - Dirección
                    ↓
Haz clic "Confirmar Pedido"
                    ↓
Backend carga Especificaciones de DB:
  (por si los precios cambiaron)
                    ↓
Clona todos los ItemOrden:
  - Copia ProductoTecnologicoId
  - Copia Cantidad
  - Copia EspecificacionesSeleccionadas
                    ↓
Crea nueva Orden:
  - GuardaNombreCliente
  - Guarda EmailCliente
  - Guarda DireccionEntrega
  - Asigna Items clonados
  - FechaCreacion = DateTime.Now
                    ↓
DbContext.SaveChangesAsync()
  (Inserta en base de datos)
                    ↓
EstadoPedido.LimpiarCarrito()
                    ↓
Redirige a /mis-pedidos
                    ↓
Usuario ve su pedido en historial
```

### 4. Ver Historial (Página MisPedidos)

```
Usuario abre /mis-pedidos
                    ↓
    Carga todas las Ordenes de DB
       con Include(Items)
           .ThenInclude(ProductoTecnologico)
           .ThenInclude(EspecificacionesSeleccionadas)
                    ↓
    Ordena por FechaCreacion DESC
       (más recientes primero)
                    ↓
    Genera tarjeta para cada orden con:
      - ID de orden
      - Fecha y hora
      - Estado
      - Datos cliente
      - Lista de items
      - Total
                    ↓
Usuario ve toda su historia de compras
```

---

## 📂 Estructura del Proyecto

```
TechStore/
│
├── 📁 Components/                    # Componentes Blazor
│   ├── 📁 Layout/
│   │   ├── MainLayout.razor          # Layout principal (header + footer)
│   │   └── MainLayout.razor.css      # Estilos del layout
│   ├── 📁 Pages/
│   │   ├── Index.razor               # Página del catálogo
│   │   ├── Checkout.razor            # Página de checkout
│   │   └── MisPedidos.razor          # Página de historial
│   ├── App.razor                     # Componente raíz
│   ├── Routes.razor                  # Configuración de rutas
│   └── _Imports.razor                # Imports globales (using statements)
│
├── 📁 Data/                          # Capa de datos
│   ├── TechStoreContext.cs           # DbContext + seed data
│   └── EstadoPedido.cs               # Servicio de carrito (scoped)
│
├── 📁 Models/                        # Modelos de datos
│   ├── ProductoTecnologico.cs
│   ├── Especificacion.cs
│   ├── Orden.cs
│   ├── ItemOrden.cs
│   └── EspecificacionOrden.cs
│
├── 📁 wwwroot/                       # Archivos estáticos
│   └── 📁 css/
│       └── app.css                   # Estilos globales
│
├── Program.cs                        # Punto de entrada
├── TechStore.csproj                  # Archivo de proyecto
├── appsettings.json                  # Configuración
├── techstore.db                      # Base de datos SQLite (auto-generada)
├── README.md                         # Este archivo
└── replit.md                         # Documentación técnica
```

---

## 🔌 API y Servicios

### EstadoPedido (Carrito)

```csharp
// Servicio scoped que vive durante toda la sesión del usuario

public class EstadoPedido
{
    public List<ItemOrden> Items { get; set; }
    
    // Agrega un producto simple al carrito
    public void AgregarProducto(ProductoTecnologico producto)
    
    // Agrega un item personalizado al carrito
    public void AgregarItem(ItemOrden item)
    
    // Elimina un item del carrito
    public void RemoverItem(ItemOrden item)
    
    // Calcula el total: Σ(item.PrecioTotal * item.Cantidad)
    public decimal PrecioTotal { get; }
    
    // Vacía completamente el carrito
    public void LimpiarCarrito()
}
```

### TechStoreContext (Base de Datos)

```csharp
// DbContext de Entity Framework Core

public class TechStoreContext : DbContext
{
    // Tablas de base de datos
    public DbSet<ProductoTecnologico> ProductosTecnologicos
    public DbSet<Especificacion> Especificaciones
    public DbSet<Orden> Ordenes
    public DbSet<ItemOrden> ItemsOrden
    
    // OnModelCreating: Incluye 8 productos + 14 especificaciones
    // de ejemplo (seed data)
}
```

### Inyección de Dependencias (Program.cs)

```csharp
// Registros de servicios:

// DbContext con SQLite
builder.Services.AddDbContext<TechStoreContext>(options =>
    options.UseSqlite("Data Source=techstore.db"));

// Carrito de la sesión del usuario
builder.Services.AddScoped<EstadoPedido>();

// Componentes Blazor interactivos
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

---

## 🔄 Cambios Realizados Respecto al Original

Este proyecto fue transformado completamente desde un concepto de "Blazing Pizza" (pizzería) a una tienda de tecnología.

### 📊 Resumen de Cambios

| Aspecto | Antes (Pizza) | Ahora (TechStore) |
|---------|---------------|-------------------|
| **Nombre Proyecto** | PizzaStore | TechStore |
| **Temática** | Pizzas y toppings | Productos tecnológicos |
| **Modelo Principal** | `Pizza` | `ProductoTecnologico` |
| **Extras** | `Topping` (pepperoni, queso) | `Especificacion` (RAM, SSD, licencias) |
| **Productos** | 8 tipos de pizza | 8 productos tech |
| **Categorías** | Specials | Hardware/Software/Servicios TI |
| **Colores** | Rojo/naranja | Cyan/púrpura/negro |
| **Tema Visual** | Cálido y acogedor | Moderno y tecnológico |
| **Tipografía** | Baloo Bhaina | Inter (Google Fonts) |

### 🔤 Cambios en Clases

| Original | Nuevo | Razón |
|----------|-------|-------|
| Pizza | ProductoTecnologico | Representa ahora productos tech |
| Topping | Especificacion | Para upgrades técnicos |
| Special | TipoProducto (enum) | Mejor organización por categorías |
| Order | Orden | Nomenclatura en español |
| OrderItem | ItemOrden | Consistencia de nombres |
| OrderTopping | EspecificacionOrden | Especificación en orden |
| PizzaStore | TechStore | Nombre de la tienda |
| OrderState | EstadoPedido | Nomenclatura en español |

### 🎨 Cambios Visuales

```css
/* Antes */
background-color: #ff6b35;      /* Naranja pizzería */
font-family: 'Baloo Bhaina';

/* Ahora */
background: linear-gradient(135deg, #0f172a, #1e293b);  /* Oscuro moderno */
font-family: 'Inter', sans-serif;                        /* Moderno y limpio */

/* Colores principales */
--primary: #06b6d4;          /* Cyan brillante */
--secondary: #8b5cf6;        /* Púrpura */
--bg-dark: #0f172a;          /* Negro profundo */
```

### 📦 Cambios en Base de Datos

```
Antes:
├── Pizzas (8 registros)
├── Toppings (16+ registros)
├── Specials (4-8 registros)
└── Orders/OrderItems

Ahora:
├── ProductosTecnologicos (8 registros)
├── Especificaciones (14 registros)
├── Ordenes
├── ItemsOrden
└── EspecificacionOrden
```

### 🛍️ Cambios en Catálogo

**ANTES - 8 Pizzas:**
- Margherita, Pepperoni, Hawaiian, Meat Lovers, etc.

**AHORA - 8 Productos Tecnológicos:**
1. 💻 Laptop Dell XPS 15 - $1,299.99
2. 🎮 PC Gaming Gamer Pro - $1,899.99
3. 🖥️ Monitor LG UltraWide 34" - $599.99
4. 📦 Microsoft Office 365 Business - $149.99
5. 💿 Windows 11 Pro - $199.99
6. 🎨 Adobe Creative Cloud - $599.99
7. 🛠️ Soporte Técnico Premium - $299.99
8. 💼 Desarrollo de Software a Medida - $4,999.99

### ✨ Cambios en Especificaciones

**ANTES - Toppings de Pizza:**
- Pepperoni (+$2.50)
- Mushrooms (+$1.50)
- Extra Cheese (+$2.00)
- Olives (+$1.75)

**AHORA - Upgrades Técnicos (14 total):**
- RAM 32GB upgrade (+$200)
- SSD 2TB NVMe upgrade (+$300)
- RTX 4080 upgrade (+$500)
- Garantía extendida 3 años (+$99)
- Licencias adicionales (x5) (+$500)
- Plan anual con descuento 20% (-$120) ⭐
- Y muchos más...

---

## ⚙️ Configuración

### appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Program.cs - Configuración Importante

```csharp
// Puerto personalizado (0.0.0.0:5000 para aceptar conexiones externas)
app.Run("http://0.0.0.0:5000");

// Base de datos SQLite
"Data Source=techstore.db"

// Inyección de servicios
builder.Services.AddScoped<EstadoPedido>();
builder.Services.AddDbContext<TechStoreContext>();
```

### Variables de Entorno

```bash
# No hay variables de entorno requeridas
# Todos los datos se guardan localmente en techstore.db
# La configuración está en appsettings.json
```

---

## 🐛 Solución de Problemas

### ❌ Problema: Base de datos vacía

**Síntoma**: No ves productos al abrir la app

**Solución**:
```bash
# Elimina la DB antigua
rm -f techstore.db

# Reinicia la app (se recreará con seed data)
dotnet run
```

### ❌ Problema: Puerto 5000 en uso

**Síntoma**: "Address already in use"

**Solución**:
```bash
# Cambia el puerto en Program.cs:
app.Run("http://0.0.0.0:5001");  // Usa 5001 en lugar de 5000
```

### ❌ Problema: Los cambios CSS no se ven

**Síntoma**: Los estilos no actualizan

**Solución**:
```bash
# Limpia el cache del navegador:
# Press Ctrl+Shift+R (Windows/Linux) o Cmd+Shift+R (Mac)

# O desde DevTools:
1. F12 → Network tab
2. Marca "Disable cache"
3. Recarga la página
```

### ❌ Problema: Errores de base de datos

**Síntoma**: "DbContext unable to establish connection"

**Solución**:
```bash
# Verifica que .NET 8.0 está instalado
dotnet --version

# Limpia y restaura
dotnet clean
dotnet restore

# Vuelve a ejecutar
dotnet run
```

---

## 🚀 Roadmap Futuro

### Fase 1 (Próximo - En Desarrollo)

- [ ] **Sistema de Autenticación de Usuarios**
  - Login/Registro con email
  - Perfiles de usuario
  - Órdenes asociadas a usuario (no anónimas)
  
- [ ] **Gestión de Inventario**
  - Stock disponible por producto
  - Notificaciones de productos agotados
  - Alertas de bajo stock

- [ ] **Sistema de Pago**
  - Integración Stripe
  - Múltiples métodos de pago
  - Confirmación de pago por email

### Fase 2 (En Planificación)

- [ ] **Búsqueda Avanzada**
  - Búsqueda por texto
  - Filtros por rango de precio
  - Ordenamiento (precio, popularidad, calificación)

- [ ] **Sistema de Comentarios y Calificaciones**
  - Reviews de productos
  - Calificaciones (1-5 estrellas)
  - Fotos de clientes

- [ ] **Carrito Persistente**
  - Guardar carrito en base de datos
  - Carrito disponible entre sesiones
  - Sincronización en múltiples dispositivos

### Fase 3 (Largo Plazo)

- [ ] **Panel de Administración**
  - CRUD de productos
  - Gestión de especificaciones
  - Reportes de ventas
  - Gestión de usuarios

- [ ] **Recomendaciones Personalizadas**
  - Basadas en historial de compras
  - Machine Learning (similar items)
  - "Usuarios también compraron"

- [ ] **Wishlist / Lista de Deseos**
  - Guardar favoritos
  - Notificaciones de descuentos
  - Compartir lista

- [ ] **Email Marketing**
  - Newsletter de nuevos productos
  - Recordatorios de carrito abandonado
  - Ofertas personalizadas

- [ ] **Análytica Avanzada**
  - Dashboard de ventas
  - Comportamiento de usuarios
  - Productos más vendidos
  - Funnel de conversión

- [ ] **Optimización Mobile**
  - App móvil nativa (iOS/Android)
  - Soporte para pagos móviles
  - One-click checkout

---

## 📋 Información de Usuario y Órdenes

### 👤 Información del Cliente en Órdenes

Actualmente, el sistema captura la siguiente información del cliente al realizar un pedido:

```csharp
public string NombreCliente { get; set; }        // Nombre completo
public string EmailCliente { get; set; }         // Email de contacto
public string DireccionEntrega { get; set; }    // Dirección completa
```

### 📊 Datos Guardados en Cada Orden

```
Orden #123
├── FechaCreacion: 2025-11-23 19:45:32
├── NombreCliente: Juan Pérez García
├── EmailCliente: juan.perez@example.com
├── DireccionEntrega: Calle Principal 123, apt. 5A
│                    28001 Madrid, España
├── Items: [
│   ├── Laptop Dell XPS 15 (Qty: 1)
│   │   ├── RAM 32GB (+$200)
│   │   ├── SSD 1TB (+$150)
│   │   └── Garantía extendida (+$99)
│   │   Subtotal: $1,749.99
│   │
│   └── Windows 11 Pro (Qty: 1)
│       └── Instalación (+$49)
│       Subtotal: $248.99
│
└── PrecioTotal: $1,998.98
```

### 🔐 Privacidad y Seguridad

⚠️ **Nota Importante**: La versión actual **NO incluye sistema de usuarios**. Todos los pedidos se guardan como anónimos. 

**Mejoras de seguridad planificadas:**
- Autenticación de usuarios
- Encriptación de datos sensibles
- HTTPS obligatorio
- Validación de inputs
- GDPR compliance
- Backup automático de datos

---

## 🙏 Créditos

### Recursos Utilizados

- **Framework**: [ASP.NET Core 8.0](https://dotnet.microsoft.com/)
- **Blazor**: [Microsoft Blazor Documentation](https://learn.microsoft.com/blazor/)
- **Imágenes**: [Unsplash](https://unsplash.com/) - Imágenes gratuitas de alta calidad
- **Tipografía**: [Google Fonts - Inter](https://fonts.google.com/)
- **Inspiración**: [Blazing Pizza Sample](https://github.com/dotnet-architecture/eShopOnBlazor)

### Contribuciones

Este proyecto fue creado como demostración de una tienda de tecnología moderna usando tecnologías Microsoft.

### Licencia

MIT License - Libre para usar, modificar y distribuir

---

## 📞 Soporte y Contacto

### ¿Necesitas ayuda?

- 📖 Lee la documentación en este README
- 🔍 Revisa la [Solución de Problemas](#solución-de-problemas)
- 💬 Consulta el archivo `replit.md` para detalles técnicos

### Reportar Bugs

Si encuentras un bug:
1. Describe el problema claramente
2. Incluye pasos para reproducirlo
3. Adjunta screenshots si es posible

### Sugerencias de Mejora

Tienes ideas para mejorar TechStore?
- Abre una issue
- Proporciona ejemplos
- Sé específico con tu propuesta

---

## 📊 Estadísticas del Proyecto

- **Líneas de Código**: ~2,500+
- **Componentes Blazor**: 6
- **Modelos de Datos**: 5
- **Productos de Ejemplo**: 8
- **Especificaciones de Ejemplo**: 14
- **Páginas Principales**: 3
- **Tiempo de Desarrollo**: 1 sesión
- **Framework**: ASP.NET Core 8.0
- **Base de Datos**: SQLite + EF Core 8.0
- **Estilos CSS**: Tema oscuro personalizado

---

## ✅ Checklist de Funcionalidades

### Implementado ✅
- [x] Catálogo de 8 productos
- [x] Filtros por categoría
- [x] Modal de personalización
- [x] Carrito interactivo
- [x] Checkout completo
- [x] Persistencia en base de datos
- [x] Historial de órdenes
- [x] Tema oscuro moderno
- [x] Responsive design
- [x] Validación de formularios
- [x] Cálculo automático de precios
- [x] 14 especificaciones técnicas

### Próximas Mejoras 🔄
- [ ] Sistema de usuarios
- [ ] Autenticación
- [ ] Integración de pagos
- [ ] Búsqueda avanzada
- [ ] Calificaciones de productos
- [ ] Panel administrativo
- [ ] Email marketing
- [ ] App móvil

---

## 🎉 ¡Gracias por usar TechStore!

Este proyecto demuestra cómo construir una aplicación web completa y profesional con ASP.NET Core 8.0 Blazor.

**¿Listo para comenzar?**

```bash
dotnet run
# Abre http://localhost:5000 en tu navegador
```

---

**Última actualización**: Noviembre 23, 2025  
**Versión**: 1.0.0  
**Estado**: ✅ Producción - Completamente Funcional
