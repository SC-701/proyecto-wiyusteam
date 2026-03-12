using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPersonaFlujo
    {
        Task<IEnumerable<PersonaResponse>> Obtener();

        Task<PersonaDetalle> Obtener(int Id);

        Task<int> Agregar(PersonaRequest persona);

        Task<int> Editar(int Id, PersonaRequest persona);

        Task<int> Eliminar(int Id);
    }
}
