using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class PersonaFlujo : IPersonaFlujo
    {
        private IPersonaDA _personaDA;

        public PersonaFlujo(IPersonaDA personaDA)
        {
            _personaDA = personaDA;
        }

        public async Task<int> Agregar(PersonaRequest persona)
        {
            return await _personaDA.Agregar(persona);
        }

        public async Task<int> Editar(int Id, PersonaRequest persona)
        {
            return await _personaDA.Editar(Id, persona);
        }

        public async Task<int> Eliminar(int Id)
        {
            return await _personaDA.Eliminar(Id);
        }

        public async Task<IEnumerable<PersonaResponse>> Obtener()
        {
            return await _personaDA.Obtener();
        }

        public async Task<PersonaDetalle> Obtener(int Id)
        {
            return await _personaDA.Obtener(Id);
        }
    }
}