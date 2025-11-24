[x] 1. Install the required packages (.NET 8.0)
[x] 2. Restart the workflow to see if the project is working
[x] 3. Verify the project is working using the feedback tool
[x] 4. Sistema de autenticación COMPLETO implementado con:
    - Autenticación basada en cookies del servidor con ASP.NET Core Cookie Authentication
    - Persistencia de sesión real (30 días) que funciona entre recargas
    - Endpoints API (/api/auth/login, /api/auth/register, /api/auth/logout) con HttpContext
    - Protección CSRF con validación de tokens antiforgery
    - AuthenticationStateProvider personalizado para hidratar estado de usuario
    - JavaScript fetch() desde el navegador para establecer cookies correctamente
    - UsuarioService con Claims y SignInAsync/SignOutAsync
    - Validaciones DataAnnotations robustas en Login, Register y Perfil
    - Páginas de Login y Register con diseño profesional y animaciones
    - Página de Perfil con validaciones, estadísticas y opción de cerrar sesión
    - Menú de usuario en header con avatar y dropdown cuando está autenticado
    - Botón de cerrar sesión visible en el menú de usuario
    - Estilos CSS dedicados (auth.css, MainLayout.razor.css) modernos y responsivos
    - Redirección automática si el usuario ya está autenticado
    - Feedback visual con mensajes de error/éxito animados
[x] 5. Sistema de autenticación SEGURO y FUNCIONAL completado exitosamente