/* Resumencito de este código:

Esta clase se encarga del acceso a datos (Data Access - DA) para Bautismo

Implementa el CRUD completo contra la base de datos
Usa Dapper para ejecutar stored procedures

BautismoDA ejecuta stored procedures mediante Dapper
Dapper permite mapear resultados de SQL a objetos automáticamente

ExecuteScalarAsync → ejecuta y devuelve un valor (ej: ID)
QueryAsync → devuelve listas de objetos

Se utilizan stored procedures para manejar la lógica en la base de datos
Se envían parámetros mediante objetos anónimos

Usa IRepositorioDapper para obtener la conexión
DA NO crea conexión directamente (respeta Clean Architecture)

Incluye validación interna para verificar si existe un registro antes de editar o eliminar

Flujo → BautismoDA → BD

Es la capa responsable de interactuar directamente con SQL Server

            Usa Dapper → ejecuta SQL/SP
            Usa SqlConnection → conexión BD
            Usa Stored Procedures → lógica BD
            Implementa interfaz IBautismoDA
            Se usa desde Flujo

*/

using Abstracciones.Interfaces.DA; // Interfaz del DA (contrato)
using Abstracciones.Modelos; // Modelos (BautismoRequest, BautismoDetalle, etc.)
using Dapper; // Micro ORM para ejecutar SQL
using Microsoft.Data.SqlClient; // Conexión a SQL Server

namespace DA // Capa de acceso a datos
{
    // Clase que implementa IBautismoDA (CRUD contra BD)
    public class BautismoDA : IBautismoDA
    {
        private IRepositorioDapper _repositorioDapper; // Proveedor de conexión
        private SqlConnection _sqlConnection; // Conexión a la BD

        // Constructor con inyección de dependencias
        public BautismoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;

            // Obtiene la conexión desde el repositorio (NO se crea aquí)
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        // INSERTAR bautismo
        public async Task<int> Agregar(BautismoRequest bautismo)
        {
            string query = @"AgregarBautismo"; // Stored Procedure

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(
                query,
                new // Parámetros enviados al SP
                {
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

            return resultadoConsulta; // Retorna ID o resultado
        }

        // EDITAR bautismo
        public async Task<int> Editar(int Id, BautismoRequest bautismo)
        {
            // Verifica que exista antes de editar
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

        // ELIMINAR bautismo
        public async Task<int> Eliminar(int Id)
        {
            // Verifica existencia antes de eliminar
            await verificarBautismoExiste(Id);

            string query = @"EliminarBautismo";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(
                query,
                new { Id = Id }
            );

            return resultadoConsulta;
        }

        // OBTENER TODOS los bautismos
        public async Task<IEnumerable<BautismoDetalle>> Obtener()
        {
            string query = @"ObtenerBautismos";

            var resultadoConsulta = await _sqlConnection.QueryAsync<BautismoDetalle>(query);

            return resultadoConsulta;
        }

        // OBTENER un bautismo por ID
        public async Task<BautismoDetalle> Obtener(int Id)
        {
            string query = @"ObtenerBautismo";

            var resultadoConsulta = await _sqlConnection.QueryAsync<BautismoDetalle>(
                query,
                new { Id = Id }
            );

            return resultadoConsulta.FirstOrDefault(); // Uno o null
        }

        // VALIDACIÓN interna
        private async Task verificarBautismoExiste(int Id)
        {
            BautismoResponse? resultadoConsultaBautismo = await Obtener(Id);

            if (resultadoConsultaBautismo == null)
                throw new Exception("No se encontró el bautismo");
        }
    }
}