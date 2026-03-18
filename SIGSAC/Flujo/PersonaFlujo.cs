/* Resumencito de este código: 
 
Esta clase ss la implementación de la capa Flujo

Es la implementación de la capa de aplicación que
actúa como intermediario entre el controller y el 
acceso a datos. En este caso delega las operaciones 
CRUD al DA, pero permite agregar lógica de negocio
sin acoplar las capas.

            Es capa Flujo
            Usa IPersonaDA
            No toca BD directo
            Usa DI
            Delega operaciones
            Permite escalar lógica
*/

using Abstracciones.Interfaces.DA; // Importa la interfaz de acceso a datos (DA)
using Abstracciones.Interfaces.Flujo; // Importa la interfaz del flujo (contrato)
using Abstracciones.Modelos; // Importa los modelos (PersonaRequest, PersonaResponse, etc.)

namespace Flujo // Namespace de la capa Flujo (Application Layer)
{
    // Clase que implementa la interfaz IPersonaFlujo
    // Flujo = intermediario entre API y DA
    public class PersonaFlujo : IPersonaFlujo
    {
        private IPersonaDA _personaDA;
        // Dependencia hacia la capa DA (NO accede directo a BD, usa interfaz)

        // Constructor con inyección de dependencias (DI)
        public PersonaFlujo(IPersonaDA personaDA)
        {
            _personaDA = personaDA; // Se inyecta la implementación de DA
        }

        // Método para agregar una persona
        public async Task<int> Agregar(PersonaRequest persona)
        {
            // Delega la operación al DA
            return await _personaDA.Agregar(persona);
        }

        // Método para editar una persona
        public async Task<int> Editar(int Id, PersonaRequest persona)
        {
            // Delega la operación al DA
            return await _personaDA.Editar(Id, persona);
        }

        // Método para eliminar una persona
        public async Task<int> Eliminar(int Id)
        {
            // Delega la operación al DA
            return await _personaDA.Eliminar(Id);
        }

        // Método para obtener todas las personas
        public async Task<IEnumerable<PersonaResponse>> Obtener()
        {
            // Delega la operación al DA
            return await _personaDA.Obtener();
        }

        // Método para obtener una persona por Id
        public async Task<PersonaDetalle> Obtener(int Id)
        {
            // Delega la operación al DA
            return await _personaDA.Obtener(Id);
        }
    }
}