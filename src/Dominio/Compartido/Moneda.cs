namespace Dominio.Compartido;

public record Moneda
{
    public static readonly Moneda Ninguno = new("");
    public static readonly Moneda Dolar = new("USD");
    public static readonly Moneda Euro = new("EUR");

    private Moneda(string codigo) => Codigo = codigo;

    public string Codigo { get; init; }

    public static readonly IReadOnlyCollection<Moneda> Todas = new[] { Dolar, Euro };

    public static Moneda DesdeCodigo(string codigo)
    {
        return Todas.FirstOrDefault(c => c.Codigo == codigo)
            ?? throw new ApplicationException($"El código de moneda '{codigo}' es inválido.");
    }
}