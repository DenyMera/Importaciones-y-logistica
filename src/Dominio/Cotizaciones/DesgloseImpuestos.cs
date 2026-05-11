using Dominio.Compartido;

namespace Dominio.Cotizaciones;

public record DesgloseImpuestos(
    Dinero AdValorem,
    Dinero Fodinfa,
    Dinero Ice,
    Dinero Iva,
    Dinero TotalImpuestos
);