namespace TechStore.Data;

public class CarritoNotificador
{
    private event Func<Task>? _onCarritoActualizado;
    
    public event Func<Task>? OnCarritoActualizado
    {
        add => _onCarritoActualizado += value;
        remove => _onCarritoActualizado -= value;
    }
    
    public async Task NotificarCambio()
    {
        if (_onCarritoActualizado != null)
        {
            var delegados = _onCarritoActualizado.GetInvocationList().OfType<Func<Task>>();
            foreach (var delegado in delegados)
            {
                try
                {
                    await delegado();
                }
                catch
                {
                    // Ignorar errores en notificaciones
                }
            }
        }
    }
}
