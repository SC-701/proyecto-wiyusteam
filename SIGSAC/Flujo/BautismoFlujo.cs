/* Resumencito de este código: 
 
Esta clase es la implementación de la capa Flujo para Bautismo

Es la implementación de la capa de aplicación que
actúa como intermediario entre el controller y el 
acceso a datos. En este caso delega las operaciones 
CRUD al DA, pero permite agregar lógica de negocio
sin acoplar las capas.

            Es capa Flujo
            Usa IBautismoDA
            No toca BD directo
            Usa DI
            Delega operaciones
            Permite escalar lógica
*/
using Abstracciones.Interfaces.DA; // Interfaz de acceso a datos (DA)
using Abstracciones.Interfaces.Flujo; // Interfaz del flujo (contrato)
using Abstracciones.Modelos; // Modelos (BautismoRequest, BautismoResponse, etc.)

namespace Flujo // Capa Flujo (Application Layer)
{
    // Clase que implementa IBautismoFlujo
    // Flujo = intermediario entre API y DA
    public class BautismoFlujo : IBautismoFlujo
    {
        private IBautismoDA _bautismoDA;
        // Dependencia hacia DA (NO accede directo a BD)

        // Constructor con inyección de dependencias (DI)
        public BautismoFlujo(IBautismoDA bautismoDA)
        {
            _bautismoDA = bautismoDA; // Se inyecta el DA
        }

        // Método para agregar un bautismo
        public async Task<int> Agregar(BautismoRequest bautismo)
        {
            // Delega la operación al DA
            return await _bautismoDA.Agregar(bautismo);
        }

        // Método para editar un bautismo
        public async Task<int> Editar(int Id, BautismoRequest bautismo)
        {
            // Delega la operación al DA
            return await _bautismoDA.Editar(Id, bautismo);
        }

        // Método para eliminar un bautismo
        public async Task<int> Eliminar(int Id)
        {
            // Delega la operación al DA
            return await _bautismoDA.Eliminar(Id);
        }

        // Método para obtener TODOS los bautismos
        public async Task<IEnumerable<BautismoResponse>> Obtener()
        {
            // Delega la operación al DA
            return await _bautismoDA.Obtener();
        }

        // Método para obtener un bautismo por Id
        public async Task<BautismoDetalle> Obtener(int Id)
        {
            // Delega la operación al DA
            return await _bautismoDA.Obtener(Id);
        }
    }
}
