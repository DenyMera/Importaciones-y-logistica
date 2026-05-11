using Dominio.Abstracciones;

namespace Dominio.Vehiculos;

public sealed class Vehiculo : Entidad
{
    private Vehiculo(string vin, string marca, string modelo, Motorizacion motorizacion)
    {
        VIN = vin;
        Marca = marca;
        Modelo = modelo;
        Motorizacion = motorizacion;
    }

    public string VIN { get; private set; }
    public string Marca { get; private set; }
    public string Modelo { get; private set; }
    public Motorizacion Motorizacion { get; private set; }

    public static Vehiculo Importar(string vin, string marca, string modelo, Motorizacion motorizacion)
    {
        if (string.IsNullOrWhiteSpace(vin) || vin.Length != 17)
        {
            throw new ArgumentException("El VIN debe tener exactamente 17 caracteres.");
        }

        var vehiculo = new Vehiculo(vin, marca, modelo, motorizacion);

        return vehiculo;
    }
}