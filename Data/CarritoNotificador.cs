namespace TechStore.Data;

public class CarritoNotificador
{
    private readonly object _lockObj = new object();
    private event Func<Task>? _onCarritoActualizado;
    
    public event Func<Task>? OnCarritoActualizado
    {
        add 
        { 
            lock (_lockObj)
            {
                _onCarritoActualizado += value;
            }
        }
        remove 
        { 
            lock (_lockObj)
            {
                _onCarritoActualizado -= value;
            }
        }
    }
    
    public async Task NotificarCambio()
    {
        Func<Task>? handlers = null;
        lock (_lockObj)
        {
            if (_onCarritoActualizado != null)
            {
                handlers = _onCarritoActualizado;
            }
        }

        if (handlers != null)
        {
            var delegados = handlers.GetInvocationList().OfType<Func<Task>>();
            foreach (var delegado in delegados)
            {
                try
                {
                    await delegado();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en notificación de carrito: {ex.Message}");
                }
            }
        }
    }
}
