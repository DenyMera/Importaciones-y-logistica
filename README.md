# Sistema de Importación de Vehículos - Domain-Driven Design (DDD)

Este proyecto implementa la capa de Dominio para un sistema de importaciones de vehículos. El diseño está guiado estrictamente por el dominio (DDD), protegiendo las reglas de negocio e invariantes sin depender de bases de datos o frameworks externos.

Se han modelado dos procesos principales del área de comercio exterior:

### Proceso 1: Cotización y Cálculo de Impuestos Aduaneros
**Descripción:** Permite estructurar los costos de importación (Costo FOB, Flete, Seguro) y calcular los impuestos según el tipo de motor del vehículo (Combustión, Híbrido, Eléctrico).
**Cómo contribuye al DDD:**
* **Agregado `CotizacionImportacion`:** Protege la invariante de que los montos no pueden ser modificados una vez que la cotización ha pasado a estado `Aprobada`.
* **Value Object `Dinero`:** Asegura que no se puedan sumar montos de diferentes monedas (ej. Dólares y Euros) mediante la sobrecarga de operadores lógicos.
* **Servicio de Dominio `ServicioCalculoAranceles`:** Extrae la lógica compleja y volátil de los porcentajes de aduana (FODINFA, ICE, IVA, Ad-Valorem) fuera de la entidad, basándose en el Value Object `Motorizacion` del vehículo.

### Proceso 2: Seguimiento Logístico de la Importación
**Descripción:** Controla el ciclo de vida y la ubicación física del vehículo desde que sale del puerto de origen hasta que es nacionalizado.
**Cómo contribuye al DDD:**
* **Agregado `Importacion`:** Protege el flujo logístico impidiendo saltos inválidos. (Ej. Lanza el error de dominio `ErroresImportacion.TransicionInvalida` si se intenta registrar el arribo de un barco que no ha zarpado).
* **Smart Enum `EstadoLogistico`:** Transforma los estados simples en objetos ricos con comportamiento, evitando el uso de tipos primitivos dispersos o sentencias condicionales (switch/if) para controlar la fase actual.
* **Errores Tipados y Patrón Result:** En lugar de lanzar excepciones técnicas, el proceso devuelve objetos `Resultado` con errores de negocio declarativos, manteniendo el flujo limpio y comprensible.