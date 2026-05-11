namespace Dominio.Abstracciones;

public class Resultado
{
    protected Resultado(bool esExitoso, Error error)
    {
        if (esExitoso && error != Error.Ninguno)
        {
            throw new InvalidOperationException("Un resultado exitoso no puede tener un error.");
        }

        if (!esExitoso && error == Error.Ninguno)
        {
            throw new InvalidOperationException("Un resultado fallido debe tener un error.");
        }

        EsExitoso = esExitoso;
        Error = error;
    }

    public bool EsExitoso { get; }
    public bool EsFallo => !EsExitoso;
    public Error Error { get; }

    public static Resultado Exito() => new(true, Error.Ninguno);
    public static Resultado Fallo(Error error) => new(false, error);
}