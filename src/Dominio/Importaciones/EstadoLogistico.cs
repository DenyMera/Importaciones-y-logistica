using Dominio.Abstracciones;

namespace Dominio.Importaciones;

public sealed record EstadoLogistico : Enumerador
{
    public static readonly EstadoLogistico EnPuertoOrigen = new("En Puerto de Origen", 1);
    public static readonly EstadoLogistico EnTransitoMaritimo = new("En Tránsito Marítimo", 2);
    public static readonly EstadoLogistico EnAduanaDestino = new("En Aduana de Destino", 3);
    public static readonly EstadoLogistico Nacionalizado = new("Nacionalizado", 4);

    private EstadoLogistico(string nombre, int valor) : base(nombre, valor)
    {
    }

    
    public static readonly IReadOnlyCollection<EstadoLogistico> Todos = new[]
    {
        EnPuertoOrigen,
        EnTransitoMaritimo,
        EnAduanaDestino,
        Nacionalizado
    };
}