using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo 
{
    public class BautismoFlujo : IBautismoFlujo
    {
        private IBautismoDA _bautismoDA;

        public BautismoFlujo(IBautismoDA bautismoDA)
        {
            _bautismoDA = bautismoDA;
        }

        public async Task<int> Agregar(BautismoRequest bautismo)
        {
            return await _bautismoDA.Agregar(bautismo);
        }

        public async Task<int> Editar(int Id, BautismoRequest bautismo)
        {
            return await _bautismoDA.Editar(Id, bautismo);
        }

        public async Task<int> Eliminar(int Id)
        {
            return await _bautismoDA.Eliminar(Id);
        }

        public async Task<IEnumerable<BautismoResponse>> Obtener()
        {
            return await _bautismoDA.Obtener();
        }

        public async Task<BautismoDetalle> Obtener(int Id)
        {
            return await _bautismoDA.Obtener(Id);
        }


    }
}
