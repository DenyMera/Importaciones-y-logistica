using Dominio.Abstracciones;
using Dominio.Compartido;

namespace Dominio.Cotizaciones;

public sealed class CotizacionImportacion : Entidad
{
    private CotizacionImportacion(
        Guid vehiculoId,
        Guid clienteId,
        Dinero costoFob,
        Dinero fleteMaritimo,
        Dinero seguro)
    {
        VehiculoId = vehiculoId;
        ClienteId = clienteId;
        CostoFob = costoFob;
        FleteMaritimo = fleteMaritimo;
        Seguro = seguro;
        Estado = EstadoCotizacion.Borrador;
    }

    public Guid VehiculoId { get; private set; }
    public Guid ClienteId { get; private set; }
    
    public Dinero CostoFob { get; private set; }
    public Dinero FleteMaritimo { get; private set; }
    public Dinero Seguro { get; private set; }
    
    public EstadoCotizacion Estado { get; private set; }

    public static CotizacionImportacion Crear(
        Guid vehiculoId,
        Guid clienteId,
        Dinero costoFob,
        Dinero fleteMaritimo,
        Dinero seguro)
    {
        return new CotizacionImportacion(vehiculoId, clienteId, costoFob, fleteMaritimo, seguro);
    }

    public Resultado Aprobar()
    {
        if (Estado != EstadoCotizacion.Borrador)
        {
            return Resultado.Fallo(ErroresCotizacion.NoEnBorrador);
        }

        Estado = EstadoCotizacion.Aprobada;
        
        // Aquí podríamos registrar un evento para notificar a la bodega o a operaciones
        // RegistrarEventoDominio(new CotizacionAprobadaEventoDominio(Id, VehiculoId));

        return Resultado.Exito();
    }

    public Resultado ActualizarCostos(Dinero nuevoFob, Dinero nuevoFlete, Dinero nuevoSeguro)
    {
        if (Estado == EstadoCotizacion.Aprobada)
        {
            // Invariante protegida: No se pueden cambiar los costos si ya se aprobó
            return Resultado.Fallo(ErroresCotizacion.YaAprobada);
        }

        CostoFob = nuevoFob;
        FleteMaritimo = nuevoFlete;
        Seguro = nuevoSeguro;

        return Resultado.Exito();
    }

    public Dinero CalcularValorCIF()
    {
        
        return CostoFob + FleteMaritimo + Seguro;
    }
}