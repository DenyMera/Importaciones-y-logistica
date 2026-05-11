namespace Dominio.Vehiculos;

public record Motorizacion
{
    private Motorizacion(string cilindrada, TipoMotor tecnologia, string denominacion)
    {
        Cilindrada = cilindrada;
        Tecnologia = tecnologia;
        Denominacion = denominacion;
    }

    public string Cilindrada { get; init; }
    public TipoMotor Tecnologia { get; init; }
    public string Denominacion { get; init; }

    public static Motorizacion Crear(string cilindrada, TipoMotor tecnologia, string denominacion)
    {
        return new Motorizacion(cilindrada, tecnologia, denominacion);
    }
}

public enum TipoMotor
{
    Combustion = 1,
    Hibrido = 2,
    Electrico = 3
}