using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IPersonaDA
    {
        Task<IEnumerable<PersonaResponse>> Obtener();

        Task<PersonaDetalle> Obtener(int Id);

        Task<int> Agregar(PersonaRequest persona);

        Task<int> Editar(int Id, PersonaRequest persona);

        Task<int> Eliminar(int Id);
    }
}
