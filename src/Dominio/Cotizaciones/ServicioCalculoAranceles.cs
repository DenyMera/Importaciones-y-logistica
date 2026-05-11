using Dominio.Compartido;
using Dominio.Vehiculos;

namespace Dominio.Cotizaciones;

public class ServicioCalculoAranceles
{
    // El servicio requiere tanto la cotización (dinero) como el vehículo (especificaciones)
    public DesgloseImpuestos CalcularImpuestos(CotizacionImportacion cotizacion, Vehiculo vehiculo)
    {
        var cif = cotizacion.CalcularValorCIF();
        var moneda = cif.Moneda;

        var fodinfa = new Dinero(cif.Monto * 0.005m, moneda);

        
        decimal porcentajeAdValorem = vehiculo.Motorizacion.Tecnologia switch
        {
            TipoMotor.Hibrido => 0.0m,     // Exonerados de arancel
            TipoMotor.Electrico => 0.0m,   // Exonerados de arancel
            TipoMotor.Combustion => 0.40m, // 40% típico para motores tradicionales
            _ => 0.40m
        };
        var adValorem = new Dinero(cif.Monto * porcentajeAdValorem, moneda);

        
        decimal porcentajeIce = vehiculo.Motorizacion.Tecnologia == TipoMotor.Combustion ? 0.15m : 0.0m;
        
        var baseIce = cif.Monto + adValorem.Monto + fodinfa.Monto;
        var ice = new Dinero(baseIce * porcentajeIce, moneda);

        
        var baseIva = baseIce + ice.Monto;
        var iva = new Dinero(baseIva * 0.15m, moneda);

        
        var totalImpuestos = adValorem + fodinfa + ice + iva;

        return new DesgloseImpuestos(adValorem, fodinfa, ice, iva, totalImpuestos);
    }
}