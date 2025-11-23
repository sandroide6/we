namespace TechStore.Data;

/// <summary>
/// Singleton service para mantener el estado de la sesión del usuario.
/// Persiste el ID del usuario actual durante toda la vida de la aplicación.
/// </summary>
public class UsuarioSession
{
    private int? _usuarioIdActual;
    
    public int? UsuarioIdActual 
    { 
        get => _usuarioIdActual;
        set => _usuarioIdActual = value;
    }

    public void LimpiarSesion()
    {
        _usuarioIdActual = null;
    }
}
