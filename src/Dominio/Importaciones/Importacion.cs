using Dominio.Abstracciones;

namespace Dominio.Importaciones;

public sealed class Importacion : Entidad
{
    private Importacion(Guid cotizacionId, string puertoOrigen, string puertoDestino)
    {
        CotizacionId = cotizacionId;
        PuertoOrigen = puertoOrigen;
        PuertoDestino = puertoDestino;
        
        // Toda importación nace esperando en el puerto de origen
        Estado = EstadoLogistico.EnPuertoOrigen;
        FechaInicioUtc = DateTime.UtcNow;
    }

    public Guid CotizacionId { get; private set; }
    public string PuertoOrigen { get; private set; }
    public string PuertoDestino { get; private set; }
    public EstadoLogistico Estado { get; private set; }
    
    // Trazabilidad de tiempos
    public DateTime FechaInicioUtc { get; private set; }
    public DateTime? FechaZarpeUtc { get; private set; }
    public DateTime? FechaArriboUtc { get; private set; }
    public DateTime? FechaNacionalizacionUtc { get; private set; }

    public static Importacion Iniciar(Guid cotizacionId, string puertoOrigen, string puertoDestino)
    {
        return new Importacion(cotizacionId, puertoOrigen, puertoDestino);
    }

    public Resultado RegistrarZarpe(DateTime fechaZarpe)
    {
        if (Estado != EstadoLogistico.EnPuertoOrigen)
        {
            return Resultado.Fallo(ErroresImportacion.TransicionInvalida);
        }

        Estado = EstadoLogistico.EnTransitoMaritimo;
        FechaZarpeUtc = fechaZarpe;

        return Resultado.Exito();
    }

    public Resultado RegistrarArribo(DateTime fechaArribo)
    {
        if (Estado != EstadoLogistico.EnTransitoMaritimo)
        {
            return Resultado.Fallo(ErroresImportacion.TransicionInvalida);
        }

        Estado = EstadoLogistico.EnAduanaDestino;
        FechaArriboUtc = fechaArribo;

        return Resultado.Exito();
    }

    public Resultado CompletarNacionalizacion(DateTime fechaNacionalizacion)
    {
        if (Estado != EstadoLogistico.EnAduanaDestino)
        {
            return Resultado.Fallo(ErroresImportacion.TransicionInvalida);
        }

        Estado = EstadoLogistico.Nacionalizado;
        FechaNacionalizacionUtc = fechaNacionalizacion;

        
        return Resultado.Exito();
    }
}