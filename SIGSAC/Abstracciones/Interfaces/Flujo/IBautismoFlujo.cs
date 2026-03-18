/* Resumencito de este código: 
            
            Es interfaz de la capa Flujo para Bautismo
            Intermediario entre API y DA
            Tiene CRUD completo
            Usa async (Task)
            Permite agregar lógica
            
Este código es CASI IGUAL al DA, y eso es intencional.
IBautismoFlujo define el contrato de la capa de aplicación 
que orquesta la lógica del sistema para la entidad Bautismo 
y delega el acceso a datos al DA.

Por qué Flujo y DA tienen lo mismo? Porque en este caso el flujo solo 
delega, pero permite agregar lógica sin afectar el DA.

*/
using Abstracciones.Modelos; // Importa los modelos que se usan como entrada y salida (BautismoRequest, BautismoResponse, etc.)

namespace Abstracciones.Interfaces.Flujo // Namespace de la capa de Flujo (Application Layer)
{
    // Interfaz (contrato) que define lo que debe hacer la capa de Flujo
    // Flujo = intermediario entre API y DA
    public interface IBautismoFlujo
    {
        // Método para obtener TODOS los registros de bautismo
        // Retorna una lista de BautismoResponse
        // Task = ejecución asíncrona
        Task<IEnumerable<BautismoResponse>> Obtener();

        // Método para obtener UN registro por Id
        // Retorna un objeto BautismoDetalle (más completo)
        Task<BautismoDetalle> Obtener(int Id);

        // Método para agregar un nuevo bautismo
        // Recibe los datos desde el API (BautismoRequest)
        // Retorna un int (Id generado o filas afectadas)
        Task<int> Agregar(BautismoRequest bautismo);

        // Método para editar un bautismo existente
        // Recibe:
        // - Id: identifica el registro
        // - bautismo: nuevos datos
        // Retorna un int (Id o filas afectadas)
        Task<int> Editar(int Id, BautismoRequest bautismo);

        // Método para eliminar un registro de bautismo
        // Recibe el Id del registro a eliminar
        // Retorna un int (Id eliminado o filas afectadas)
        Task<int> Eliminar(int Id);
    }
}
}
