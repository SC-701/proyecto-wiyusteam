using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class BautismoDA : IBautismoDA    
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public BautismoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        public async Task<int> Agregar(BautismoRequest bautismo)
        {
            string query = @"AgregarBautismo";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(
                query,
                new
                {
                    BautizandoId = bautismo.BautizandoId ,
                    PadreId = bautismo.PadreId ,
                    MadreId = bautismo.MadreId,
                    TipoUnionPadres = bautismo.TipoUnionPadres ,
                    FechaMatrimonioPadres = bautismo.FechaMatrimonioPadres ,
                    AbueloPaternoId = bautismo.AbueloPaternoId,
                    AbuelaPaternaId = bautismo.AbuelaPaternaId,
                    AbueloMaternoId = bautismo.AbueloMaternoId ,
                    AbuelaMaternaId = bautismo.AbuelaMaternaId,
                    PadrinoId = bautismo.PadrinoId,
                    MadrinaId = bautismo.MadrinaId,
                    DeclaranteId = bautismo.DeclaranteId,
                }
            );

            return resultadoConsulta;
        }
        public async Task<int> Editar(int Id, BautismoRequest bautismo)
        {
            await verificarBautismoExiste(Id);

            string query = @"EditarBautismo";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(
                query,
                new
                {
                    Id = Id,
                    BautizandoId = bautismo.BautizandoId,
                    PadreId = bautismo.PadreId,
                    MadreId = bautismo.MadreId,
                    TipoUnionPadres = bautismo.TipoUnionPadres,
                    FechaMatrimonioPadres = bautismo.FechaMatrimonioPadres,
                    AbueloPaternoId = bautismo.AbueloPaternoId,
                    AbuelaPaternaId = bautismo.AbuelaPaternaId,
                    AbueloMaternoId = bautismo.AbueloMaternoId,
                    AbuelaMaternaId = bautismo.AbuelaMaternaId,
                    PadrinoId = bautismo.PadrinoId,
                    MadrinaId = bautismo.MadrinaId,
                    DeclaranteId = bautismo.DeclaranteId,

                }
            );

            return resultadoConsulta;
        }

        public async Task<int> Eliminar(int Id)
        {
            await verificarBautismoExiste(Id);
            string query = @"EliminarBautismo";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(
                query,
                new { Id = Id }
            );

            return resultadoConsulta;
        }

        public async Task<IEnumerable<BautismoDetalle>> Obtener()
        {
            string query = @"ObtenerBautismos";

            var resultadoConsulta = await _sqlConnection.QueryAsync<BautismoDetalle>(query);

            return resultadoConsulta;
        }



        public async Task<BautismoDetalle> Obtener(int Id)
        {
            string query = @"ObtenerBautismo";

            var resultadoConsulta = await _sqlConnection.QueryAsync<BautismoDetalle>(
                query,
                new { Id = Id }
            );

            return resultadoConsulta.FirstOrDefault();
        }
        private async Task verificarBautismoExiste(int Id)
        {
            BautismoResponse? resultadoConsultaBautismo = await Obtener(Id);

            if (resultadoConsultaBautismo == null)
                throw new Exception("No se encontró el bautismo");
        }

    }
}
