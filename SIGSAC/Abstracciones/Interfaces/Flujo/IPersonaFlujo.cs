/* Resumencito de este código: 
 
            Es interfaz de la capa Flujo
            Intermediario entre API y DA
            Tiene CRUD completo
            Usa async (Task)
            Permite agregar lógica
        
Este código es CASI IGUAL al DA, y eso es intencional.
IPersonaFlujo define el contrato de la capa de aplicación 
que orquesta la lógica del sistema y delega el acceso a datos al DA.

Por qué Flujo y DA tienen lo mismo? Porque en este caso el flujo solo 
delega, pero permite agregar lógica sin afectar el DA.

*/


using Abstracciones.Modelos; // Importa los modelos que se usan como entrada y salida (PersonaRequest, PersonaResponse, etc.)

namespace Abstracciones.Interfaces.Flujo // Namespace de la capa de Flujo (Application Layer)
{
    // Interfaz (contrato) que define lo que debe hacer la capa de Flujo
    // Flujo = intermediario entre API y DA
    public interface IPersonaFlujo
    {
        // Método para obtener TODAS las personas
        // Retorna una lista de PersonaResponse
        // Task = ejecución asíncrona
        Task<IEnumerable<PersonaResponse>> Obtener();

        // Método para obtener UNA persona por Id
        // Retorna un objeto PersonaDetalle (más completo)
        Task<PersonaDetalle> Obtener(int Id);

        // Método para agregar una nueva persona
        // Recibe los datos desde el API (PersonaRequest)
        // Retorna un int (Id generado o filas afectadas)
        Task<int> Agregar(PersonaRequest persona);

        // Método para editar una persona existente
        // Recibe:
        // - Id: identifica el registro
        // - persona: nuevos datos
        // Retorna un int (Id o filas afectadas)
        Task<int> Editar(int Id, PersonaRequest persona);

        // Método para eliminar una persona
        // Recibe el Id del registro a eliminar
        // Retorna un int (Id eliminado o filas afectadas)
        Task<int> Eliminar(int Id);
    }
}
