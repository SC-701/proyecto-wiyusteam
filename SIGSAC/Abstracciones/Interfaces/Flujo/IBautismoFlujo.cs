using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IBautismoFlujo
    {
        Task<IEnumerable<BautismoResponse>> Obtener();

        Task<BautismoDetalle> Obtener(int Id);

        Task<int> Agregar(BautismoRequest bautismo);

        Task<int> Editar(int Id, BautismoRequest bautismo);

        Task<int> Eliminar(int Id);
    }
}
