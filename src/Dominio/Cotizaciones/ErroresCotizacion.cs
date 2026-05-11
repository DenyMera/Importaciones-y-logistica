using Dominio.Abstracciones;

namespace Dominio.Cotizaciones;

public static class ErroresCotizacion
{
    public static readonly Error YaAprobada = new(
        "Cotizacion.YaAprobada",
        "La cotización ya fue aprobada y sus montos no pueden ser modificados."
    );

    public static readonly Error NoEnBorrador = new(
        "Cotizacion.NoEnBorrador",
        "La operación solo se puede realizar si la cotización está en estado borrador."
    );
}