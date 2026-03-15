using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IBautismoDA
    {
        Task<IEnumerable<BautismoResponse>> Obtener();

        Task<BautismoDetalle> Obtener(int Id);

        Task<int> Agregar(BautismoRequest bautismo);

        Task<int> Editar(int Id, BautismoRequest bautismo);

        Task<int> Eliminar(int Id);
    }
}
