/* Resumencito de este código:

Esta clase se encarga del acceso a datos (Data Access - DA)

Implementa el CRUD completo contra la base de datos
Usa Dapper para ejecutar stored procedures

PersonaDA ejecuta stored procedures mediante Dapper
Dapper permite mapear resultados de SQL a objetos automáticamente

ExecuteScalarAsync → ejecuta y devuelve un valor (ej: ID)
QueryAsync → devuelve listas de objetos

Se utilizan stored procedures para manejar la lógica en la base de datos
Se envían parámetros mediante objetos anónimos

Usa IRepositorioDapper para obtener la conexión
DA NO crea conexión directamente (respeta Clean Architecture)

Incluye validación interna para verificar si existe un registro antes de editar o eliminar

Flujo → PersonaDA → BD

Es la capa responsable de interactuar directamente con SQL Server

            Usa Dapper → ejecuta SQL/SP
            Usa SqlConnection → conexión BD
            Usa Stored Procedures → lógica BD
            Implementa interfaz IPersonaDA
            Se usa desde Flujo

*/

using Abstracciones.Interfaces.DA; // Interfaz que define el contrato del DA
using Abstracciones.Modelos; // Modelos (PersonaRequest, PersonaResponse, etc.)
using Dapper; // Librería Dapper (micro ORM para ejecutar SQL)
//using Microsoft.Data.SqlClient; // Conexión a SQL Server
using Npgsql;
using System.Data;

namespace DA // Namespace de la capa de acceso a datos
{
    // Clase que implementa IPersonaDA (CRUD contra la base de datos)
    public class PersonaDA : IPersonaDA
    {
        private IRepositorioDapper _repositorioDapper; // Repositorio que da la conexión
        private IDbConnection _npgsqlConnection; // Conexión a la BD

        // Constructor con inyección de dependencias
        public PersonaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;

            // Obtiene la conexión desde el repositorio (NO se crea directo aquí)
            _npgsqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        // INSERTAR persona
        public async Task<int> Agregar(PersonaRequest persona)
        {
            string query = @"SELECT agregar_persona(
    @Nombre,
    @PrimerApellido,
    @SegundoApellido,
    @Cedula,
    @Pasaporte,
    @Sexo,
    @FechaNacimiento,
    @HoraNacimiento,
    @LugarNacimiento,
    @Nacionalidad,
    @EstadoCivil,
    @Profesion,
    @Religion,
    @Direccion
)";
// Nombre del Stored Procedure

            // Ejecuta el SP y devuelve un valor (ID generado)
            var resultadoConsulta = await _npgsqlConnection.ExecuteScalarAsync<int>(
                query,
                new // Parámetros enviados al SP
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

            return resultadoConsulta; // Retorna el resultado
        }

        // EDITAR persona
        public async Task<int> Editar(int Id, PersonaRequest persona)
        {
            // Valida que exista antes de editar
            await verificarPersonaExiste(Id);

            string query = @"
SELECT editar_persona(
    @Id,
    @Nombre,
    @PrimerApellido,
    @SegundoApellido,
    @Cedula,
    @Pasaporte,
    @Sexo,
    @FechaNacimiento,
    @HoraNacimiento,
    @LugarNacimiento,
    @Nacionalidad,
    @EstadoCivil,
    @Profesion,
    @Religion,
    @Direccion
)";

            var resultadoConsulta = await _npgsqlConnection.ExecuteScalarAsync<int>(
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

        // ELIMINAR persona
        public async Task<int> Eliminar(int Id)
        {
            // Valida que exista antes de eliminar
            await verificarPersonaExiste(Id);

            string query = @"SELECT eliminar_persona(@Id)";

            var resultadoConsulta = await _npgsqlConnection.ExecuteScalarAsync<int>(
                query,
                new { Id = Id }
            );

            return resultadoConsulta;
        }

        // OBTENER TODAS las personas
        public async Task<IEnumerable<PersonaResponse>> Obtener()
        {
            string query = @"SELECT * FROM obtener_personas()";

            // Devuelve lista de objetos mapeados automáticamente
            var resultadoConsulta =
                await _npgsqlConnection.QueryAsync<PersonaResponse>(query);

            return resultadoConsulta;
        }

        // OBTENER una persona por ID
        public async Task<PersonaDetalle> Obtener(int Id)
        {
            string query = @"SELECT * FROM obtener_persona(@Id)";

            var resultadoConsulta = await _npgsqlConnection.QueryAsync<PersonaDetalle>(
                query,
                new { Id = Id }
            );

            return resultadoConsulta.FirstOrDefault(); // Devuelve uno o null
        }

        // Método privado para validar existencia
        private async Task verificarPersonaExiste(int Id)
        {
            PersonaResponse? resultadoConsultaPersona = await Obtener(Id);

            // Si no existe → error
            if (resultadoConsultaPersona == null)
                throw new Exception("No se encontró la persona");
        }
    }
}