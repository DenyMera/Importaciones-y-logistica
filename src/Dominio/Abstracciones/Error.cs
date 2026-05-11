namespace Dominio.Abstracciones;

public record Error(string Codigo, string Mensaje)
{
    public static readonly Error Ninguno = new(string.Empty, string.Empty);
    
    public static readonly Error Nulo = new("Error.Nulo", "El valor proporcionado es nulo");
}