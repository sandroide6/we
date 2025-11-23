# TechStore - Tienda de Tecnología

## Descripción General

TechStore es una tienda en línea moderna y profesional especializada en productos de tecnología, desarrollada con ASP.NET Core 8.0 Blazor Server. La aplicación permite a los usuarios explorar, personalizar y comprar productos tecnológicos incluyendo hardware (laptops, PCs, monitores), software (licencias, suites de oficina) y servicios de TI (soporte técnico, desarrollo a medida).

**Fecha de creación**: Noviembre 23, 2025

## Características Principales

### 🔐 Sistema de Autenticación
- Login y registro de usuarios completamente funcional
- Hashing seguro de contraseñas con SHA256
- Validación de email y contraseña
- Perfil de usuario con información personal
- Cambio de contraseña seguro
- Sesión de usuario persistent

### 🛒 Catálogo Interactivo
- Navegación por categorías: Hardware, Software y Servicios TI
- Tarjetas de productos con imágenes reales de alta calidad
- Filtros dinámicos para buscar productos específicos
- Descripción detallada de cada producto

### 🎨 Personalización de Productos
- Sistema modal para personalizar productos con especificaciones adicionales
- Opciones de upgrade (RAM, SSD, garantías extendidas, etc.)
- Cálculo automático de precio según las especificaciones seleccionadas
- Vista previa en tiempo real del precio total

### 🛍️ Carrito de Compras
- Gestión completa del carrito con vista de resumen
- Modificación de cantidades de productos
- Eliminación de items del carrito
- Cálculo automático de totales
- Checkout requiere autenticación

### 📦 Sistema de Pedidos
- Formulario de checkout con validación de datos
- Captura de información del cliente (nombre, email, dirección)
- Historial completo de pedidos realizados por usuario
- Visualización detallada de especificaciones personalizadas en pedidos pasados
- Órdenes vinculadas a cuentas de usuario

### 👤 Perfil de Usuario
- Visualización y edición de información personal
- Dirección de envío guardada
- Teléfono de contacto
- Historial de membresía
- Cambio seguro de contraseña

### 🎨 Diseño Moderno y Profesional
- Tema oscuro con gradientes tecnológicos (azul cian y negro)
- Tipografía moderna con fuente Inter
- Animaciones suaves y transiciones fluidas
- Interfaz responsive y optimizada para diferentes dispositivos
- Efectos hover y estados interactivos
- Menú dropdown con opciones de usuario

## Arquitectura Técnica

### Stack Tecnológico
- **Framework**: ASP.NET Core 8.0
- **UI**: Blazor Server-Side
- **Base de Datos**: SQLite con Entity Framework Core 8.0
- **Lenguaje**: C# 12 (.NET 8)

### Estructura del Proyecto

```
TechStore/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor           # Layout principal con header y footer
│   │   └── MainLayout.razor.css       # Estilos del layout
│   ├── Pages/
│   │   ├── Index.razor                # Catálogo de productos
│   │   ├── Login.razor                # Página de login
│   │   ├── Register.razor             # Página de registro
│   │   ├── Perfil.razor               # Página de perfil de usuario
│   │   ├── Checkout.razor             # Página de checkout
│   │   └── MisPedidos.razor           # Historial de pedidos
│   ├── App.razor                      # Componente raíz de la app
│   ├── Routes.razor                   # Configuración de rutas
│   └── _Imports.razor                 # Imports globales
├── Data/
│   ├── TechStoreContext.cs            # Contexto de Entity Framework
│   ├── EstadoPedido.cs                # Servicio de estado del carrito
│   └── UsuarioService.cs              # Servicio de autenticación
├── Models/
│   ├── ProductoTecnologico.cs         # Modelo de producto
│   ├── Especificacion.cs              # Modelo de especificaciones
│   ├── Usuario.cs                     # Modelo de usuario
│   ├── Orden.cs                       # Modelo de orden
│   ├── ItemOrden.cs                   # Modelo de item de orden
│   └── EspecificacionOrden.cs         # Modelo de especificación en orden
├── wwwroot/
│   └── css/
│       └── app.css                    # Estilos globales de la aplicación
├── Program.cs                         # Punto de entrada de la aplicación
├── TechStore.csproj                   # Archivo de proyecto
└── appsettings.json                   # Configuración de la aplicación
```

### Modelos de Datos

#### Usuario
Representa un usuario registrado en el sistema.
- `Id`: Identificador único
- `Email`: Email único del usuario
- `Nombre`: Nombre del usuario
- `Apellido`: Apellido del usuario
- `Contraseña`: Contraseña hasheada con SHA256
- `Telefono`: Número de teléfono de contacto
- `Dirección`: Dirección de envío
- `FechaRegistro`: Fecha de creación de la cuenta
- `UltimoLogin`: Fecha del último login
- `EstaActivo`: Estado de la cuenta (activa/inactiva)
- `Ordenes`: Lista de órdenes del usuario

#### ProductoTecnologico
Representa los productos tecnológicos disponibles en la tienda.
- `Id`: Identificador único
- `Nombre`: Nombre del producto
- `Descripcion`: Descripción detallada
- `PrecioBase`: Precio base del producto
- `ImagenUrl`: URL de la imagen del producto
- `Tipo`: Enum (Hardware, Software, Servicio)
- `Categoria`: Categoría específica del producto
- `EspecificacionesDisponibles`: Lista de especificaciones disponibles

#### Especificacion
Representa opciones adicionales o upgrades para los productos.
- `Id`: Identificador único
- `Nombre`: Nombre de la especificación
- `PrecioAdicional`: Costo adicional (puede ser negativo para descuentos)
- `ProductoTecnologicoId`: FK al producto

#### Orden
Representa un pedido realizado por un cliente.
- `Id`: Identificador único
- `FechaCreacion`: Fecha y hora del pedido
- `DireccionEntrega`: Dirección de entrega
- `NombreCliente`: Nombre del cliente
- `EmailCliente`: Email del cliente
- `UsuarioId`: FK al usuario (NUEVO)
- `Usuario`: Referencia al usuario (NUEVO)
- `Items`: Lista de items en la orden

#### ItemOrden
Representa un producto dentro de una orden.
- `Id`: Identificador único
- `ProductoTecnologicoId`: FK al producto
- `Cantidad`: Cantidad del producto
- `PrecioBaseProducto`: Precio base guardado
- `EspecificacionesSeleccionadas`: Lista de especificaciones seleccionadas

#### EspecificacionOrden
Representa una especificación seleccionada en un item de orden.
- `Id`: Identificador único
- `EspecificacionId`: FK a la especificación
- `PrecioEspecificacion`: Precio guardado de la especificación

### Capa de Datos

#### TechStoreContext
Contexto de Entity Framework que gestiona la conexión a la base de datos SQLite. Incluye datos de ejemplo (seed data) con 8 productos tecnológicos y 14 especificaciones predefinidas. Gestiona todas las entidades: Productos, Especificaciones, Usuarios, Órdenes, Items de Orden.

#### EstadoPedido
Servicio scoped que gestiona el estado del carrito de compras durante la sesión del usuario. Permite agregar productos simples o personalizados, remover items y calcular totales.

#### UsuarioService
Servicio scoped que gestiona la autenticación de usuarios. Funcionalidades:
- `RegistrarAsync()`: Crear nueva cuenta de usuario
- `LoginAsync()`: Autenticar usuario existente
- `LogoutAsync()`: Cerrar sesión
- `ObtenerUsuarioPorIdAsync()`: Obtener datos del usuario
- `ActualizarPerfilAsync()`: Actualizar información personal
- `CambiarContraseñaAsync()`: Cambiar contraseña segura
- Hashing seguro de contraseñas con SHA256
- Gestión de `UsuarioActual` para la sesión

### Flujo de Datos

1. **Catálogo → Carrito**: Los productos se agregan al servicio `EstadoPedido`
2. **Personalización**: Modal permite seleccionar especificaciones antes de agregar al carrito
3. **Checkout**: Clona los items del carrito y los persiste en la base de datos
4. **Historial**: Carga las órdenes con todas sus relaciones usando Include/ThenInclude

### Características de Seguridad
- Validación de formularios en el checkout
- Prevención de inyección SQL mediante Entity Framework
- Separación de concerns entre presentación y datos

## Productos Incluidos

### Hardware
1. **Laptop Dell XPS 15** - $1,299.99
   - RAM 32GB upgrade: +$200
   - SSD 1TB upgrade: +$150
   - Garantía extendida 3 años: +$99

2. **PC Gaming Gamer Pro** - $1,899.99
   - RAM 64GB upgrade: +$400
   - SSD 2TB NVMe upgrade: +$300
   - RTX 4080 upgrade: +$500

3. **Monitor LG UltraWide 34"** - $599.99
   - Brazo monitor ergonómico: +$79
   - Calibración profesional: +$149

### Software
4. **Microsoft Office 365 Business** - $149.99
   - Licencias adicionales (x5): +$500
   - Soporte prioritario: +$99

5. **Windows 11 Pro** - $199.99
   - Instalación y configuración: +$49

6. **Adobe Creative Cloud** - $599.99
   - Plan anual (descuento 20%): -$120

### Servicios TI
7. **Soporte Técnico Premium** - $299.99
   - Visitas on-site incluidas: +$199

8. **Desarrollo de Software a Medida** - $4,999.99
   - Mantenimiento 1 año incluido: +$999

## Instrucciones de Uso

### Iniciar la Aplicación
```bash
dotnet run
```
La aplicación estará disponible en: `http://0.0.0.0:5000`

### Crear una Cuenta (Registro)
1. Haz clic en el botón "Registrarse" en el header
2. Completa el formulario con:
   - Nombre completo
   - Email (debe ser único)
   - Contraseña (mínimo 6 caracteres)
   - Confirmación de contraseña
3. Se creará tu cuenta automáticamente y serás redirigido al catálogo

### Iniciar Sesión
1. Haz clic en "Iniciar Sesión" en el header
2. Ingresa tu email y contraseña
3. Se abrirá tu sesión y verás tu nombre en el header

### Explorar el Catálogo
1. Navega a la página principal
2. Usa los filtros de categoría para ver productos específicos
3. Haz clic en "Personalizar" para productos con especificaciones
4. Selecciona las opciones deseadas y agrega al carrito

### Realizar un Pedido
1. Agrega productos al carrito
2. Haz clic en el carrito en el header (muestra cantidad y total)
3. Si no estás logueado, serás redirigido a login
4. Revisa tu carrito y ajusta cantidades
5. Completa el formulario de checkout con dirección de envío
6. Confirma el pedido

### Ver Historial de Pedidos
1. Haz clic en tu nombre en el header (aparecerá un menú)
2. Selecciona "Mis Pedidos"
3. Revisa todos tus pedidos realizados con detalles completos

### Gestionar tu Perfil
1. Haz clic en tu nombre en el header
2. Selecciona "Mi Perfil"
3. Actualiza tu información personal (nombre, apellido, teléfono, dirección)
4. Cambia tu contraseña de forma segura
5. Cierra sesión desde el botón "Cerrar Sesión"

## Mejoras Futuras Sugeridas

### Funcionalidad
- Sistema de autenticación de usuarios
- Búsqueda por texto de productos
- Sistema de reviews y calificaciones
- Comparación de productos
- Wishlist o lista de deseos
- Descuentos y cupones
- Múltiples métodos de pago
- Seguimiento de envíos

### Técnicas
- Migraciones de Entity Framework
- Pruebas unitarias e integración
- Cache de productos
- Paginación de catálogo
- Imágenes optimizadas
- PWA (Progressive Web App)
- Notificaciones en tiempo real

## Notas de Desarrollo

### Sesión Nov 23, 2025 - Correcciones de Threading y Persistencia

**Problema Principal**: Error de threading "The current thread is not associated with the Dispatcher" cuando el usuario se registraba.

**Solución Implementada**:
1. **Removido patrón de eventos cross-thread**: Eliminamos el evento `OnUsuarioChanged` que intentaba sincronizar MainLayout desde un contexto diferente
2. **Creado UsuarioSession (Singleton)**: Servicio que guarda el ID del usuario actual de forma persistente
3. **Persistencia de sesión**: Cuando se registra/login, se guarda el ID en UsuarioSession. Al inicializarse UsuarioService después de forceLoad, carga el usuario desde la BD
4. **ForceLoad: true**: Usamos NavigateTo con forceLoad:true para recargar la página completamente después del registro/login
5. **Carga síncrona**: CargarUsuarioActual() usa .Find() en lugar de FindAsync() para cargar el usuario en el constructor

**Ventajas del nuevo sistema**:
- ✅ Sin conflictos de threading
- ✅ Sesión persiste después de forceLoad
- ✅ MainLayout se actualiza cuando navega a "/"
- ✅ Logout limpia la sesión correctamente

### Correcciones Importantes Implementadas
- **Persistencia de Especificaciones**: Se corrigió un problema crítico donde las especificaciones personalizadas no se guardaban correctamente. Ahora se cargan las entidades de especificación desde la base de datos antes de persistir la orden.
- **Clonación de Items**: Los items del carrito se clonan correctamente antes de guardar para evitar problemas con Entity Framework.
- **Navegaciones EF**: Se asegura que todas las navegaciones de Entity Framework estén correctamente pobladas usando Include/ThenInclude.
- **Sistema de Autenticación**: Implementado sistema completo de login/registro con:
  - Hashing seguro de contraseñas
  - Validación de datos
  - Gestión de sesiones
  - Vinculación de órdenes a usuarios
- **Protección de Rutas**: Checkout y "Mis Pedidos" ahora requieren autenticación
- **Menú de Usuario**: Dropdown en header que muestra opciones cuando se está logueado

### Performance
- Una sola consulta batch para cargar especificaciones en checkout
- Uso eficiente de Include/ThenInclude para cargar relaciones
- Queries optimizadas por Entity Framework

## Créditos
- Imágenes de productos: Unsplash
- Fuente tipográfica: Google Fonts (Inter)
- Framework: Microsoft ASP.NET Core Blazor

---

**Nota**: Este proyecto fue diseñado como una demostración de una tienda de tecnología moderna y profesional. Todos los productos y precios son ficticios con fines demostrativos.
