/* Resumencito de este código: 
        
IBautismoDA es una interfaz que define el contrato de acceso a datos
para la entidad Bautismo, incluyendo operaciones CRUD asíncronas que 
interactúan con la base de datos.

Usa BautismoRequest para entrada de datos
Usa BautismoDetalle para salida de datos

OJO: CAPA DA RETORNA Datos reales (int, objetos)
*/
using Abstracciones.Modelos; // Importa los modelos que se usan como parámetros y respuestas (BautismoRequest, BautismoDetalle, etc.)

namespace Abstracciones.Interfaces.DA // Namespace de la capa de Abstracciones para Data Access (DA)
{
    // Interfaz (contrato) que define lo que debe implementar la capa de acceso a datos (DA)
    public interface IBautismoDA
    {
        // Método para obtener TODOS los registros de bautismo desde la base de datos
        // Task = operación asíncrona
        // IEnumerable<BautismoDetalle> = lista de resultados
        Task<IEnumerable<BautismoDetalle>> Obtener();

        // Método para obtener UN registro de bautismo por Id
        // Retorna un objeto BautismoDetalle
        // Puede devolver null si no existe
        Task<BautismoDetalle> Obtener(int Id);

        // Método para agregar un nuevo bautismo en la base de datos
        // Recibe un objeto BautismoRequest (datos desde el API)
        // Devuelve un int (Id generado o filas afectadas)
        Task<int> Agregar(BautismoRequest bautismo);

        // Método para editar un registro de bautismo
        // Recibe:
        // - Id: identifica el registro
        // - bautismo: nuevos datos
        // Devuelve un int (Id actualizado o filas afectadas)
        Task<int> Editar(int Id, BautismoRequest bautismo);

        // Método para eliminar un registro de bautismo
        // Recibe el Id del registro
        // Devuelve un int (Id eliminado o filas afectadas)
        Task<int> Eliminar(int Id);
    }
}
