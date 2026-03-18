/* Resumencito de este código: 
        
IPersonaDA es una interfaz que define el contrato de acceso a datos
para la entidad Persona, incluyendo operaciones CRUD asíncronas que 
interactúan con la base de datos.

OJO: CAPA DA RETORNA Datos reales (int, objetos)
*/

using Abstracciones.Modelos; // Importa los modelos que se usan como parámetros y respuestas (PersonaRequest, PersonaResponse, etc.)

namespace Abstracciones.Interfaces.DA // Namespace de la capa de Abstracciones para Data Access (DA)
{
    // Interfaz (contrato) que define lo que debe implementar la capa de acceso a datos (DA)
    public interface IPersonaDA
    {
        // Método para obtener TODAS las personas desde la base de datos
        // Task = operación asíncrona
        // IEnumerable<PersonaResponse> = colección (lista) de personas en formato de respuesta
        Task<IEnumerable<PersonaResponse>> Obtener();

        // Método para obtener UNA persona específica por Id
        // Retorna un objeto más detallado (PersonaDetalle)
        // Puede devolver null si no existe
        Task<PersonaDetalle> Obtener(int Id);

        // Método para agregar una nueva persona en la base de datos
        // Recibe un objeto PersonaRequest (datos que vienen del API)
        // Devuelve un int (generalmente el Id generado o afectado)
        Task<int> Agregar(PersonaRequest persona);

        // Método para editar una persona existente
        // Recibe:
        // - Id: identifica el registro a actualizar
        // - persona: nuevos datos
        // Devuelve un int (Id del registro actualizado o filas afectadas)
        Task<int> Editar(int Id, PersonaRequest persona);

        // Método para eliminar una persona
        // Recibe el Id del registro a eliminar
        // Devuelve un int (Id eliminado o filas afectadas)
        Task<int> Eliminar(int Id);
    }
}