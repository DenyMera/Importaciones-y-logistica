using Dominio.Abstracciones;

namespace Dominio.Importaciones;

public static class ErroresImportacion
{
    public static readonly Error TransicionInvalida = new(
        "Importacion.TransicionInvalida",
        "No se puede saltar al estado logístico solicitado desde el estado actual."
    );

    public static readonly Error YaNacionalizado = new(
        "Importacion.YaNacionalizado",
        "El vehículo ya completó su proceso de importación y no puede retroceder."
    );
}