using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class PersonaDA : IPersonaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public PersonaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<int> Agregar(PersonaRequest persona)
        {
            string query = @"AgregarPersona";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(
                query,
                new
                {
                    Nombre = persona.Nombre,
                    PrimerApellido = persona.PrimerApellido,
                    SegundoApellido = persona.SegundoApellido,
                    Cedula = persona.Cedula,
                    Pasaporte = persona.Pasaporte,
                    Sexo = persona.Sexo,
                    FechaNacimiento = persona.FechaNacimiento,
                    HoraNacimiento = persona.HoraNacimiento,
                    LugarNacimiento = persona.LugarNacimiento,
                    Nacionalidad = persona.Nacionalidad,
                    EstadoCivil = persona.EstadoCivil,
                    Profesion = persona.Profesion,
                    Religion = persona.Religion,
                    Direccion = persona.Direccion
                }
            );

            return resultadoConsulta;
        }

        public async Task<int> Editar(int Id, PersonaRequest persona)
        {
            await verificarPersonaExiste(Id);

            string query = @"EditarPersona";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(
                query,
                new
                {
                    Id = Id,
                    Nombre = persona.Nombre,
                    PrimerApellido = persona.PrimerApellido,
                    SegundoApellido = persona.SegundoApellido,
                    Cedula = persona.Cedula,
                    Pasaporte = persona.Pasaporte,
                    Sexo = persona.Sexo,
                    FechaNacimiento = persona.FechaNacimiento,
                    HoraNacimiento = persona.HoraNacimiento,
                    LugarNacimiento = persona.LugarNacimiento,
                    Nacionalidad = persona.Nacionalidad,
                    EstadoCivil = persona.EstadoCivil,
                    Profesion = persona.Profesion,
                    Religion = persona.Religion,
                    Direccion = persona.Direccion
                }
            );

            return resultadoConsulta;
        }

        public async Task<int> Eliminar(int Id)
        {
            await verificarPersonaExiste(Id);
            string query = @"EliminarPersona";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<int>(
                query,
                new { Id = Id }
            );

            return resultadoConsulta;
        }

        public async Task<IEnumerable<PersonaResponse>> Obtener()
        {
            string query = @"ObtenerPersonas";

            var resultadoConsulta = await _sqlConnection.QueryAsync<PersonaResponse>(query);

            return resultadoConsulta;
        }

        public async Task<PersonaDetalle> Obtener(int Id)
        {
            string query = @"ObtenerPersona";

            var resultadoConsulta = await _sqlConnection.QueryAsync<PersonaDetalle>(
                query,
                new { Id = Id }
            );

            return resultadoConsulta.FirstOrDefault();
        }


        private async Task verificarPersonaExiste(int Id)
        {
            PersonaResponse? resultadoConsultaPersona = await Obtener(Id);

            if (resultadoConsultaPersona == null)
                throw new Exception("No se encontró la persona");
        }
    }
}