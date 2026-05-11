namespace Dominio.Abstracciones;

public abstract class Entidad
{
    private readonly List<IEventoDominio> _eventosDominio = new();

    public Guid Id { get; init; } = Guid.NewGuid();

    public IReadOnlyList<IEventoDominio> ObtenerEventosDominio()
    {
        return _eventosDominio.ToList();
    }

    public void LimpiarEventosDominio()
    {
        _eventosDominio.Clear();
    }

    protected void RegistrarEventoDominio(IEventoDominio evento)
    {
        _eventosDominio.Add(evento);
    }
}