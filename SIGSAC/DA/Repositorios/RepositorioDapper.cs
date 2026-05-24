/* Resumencito de este código: 
 
Esta clase crea y devuelve la conexión a la base de datos
RepositorioDapper encapsula la creación de la conexión a 
la base de datos usando IConfiguration

IConfiguration permite acceder a valores del appsettings.json
Para NO repetir conexión en todo el sistema
Centraliza la conexión a la base de datos y permite reutilizarla
DA NO crea conexión directo 

Es una clase que implementa el patrón repositorio y se encarga de
obtener la conexión a la base de datos utilizando IConfiguration 
para leer la cadena de conexión desde appsettings.json y crear un 
objeto SqlConnection reutilizable.

            Usa IConfiguration → lee appsettings
            Usa SqlConnection → conecta BD
            Centraliza conexión
            Implementa interfaz
            Se usa en DA

*/

using Abstracciones.Interfaces.DA; // Importa la interfaz que este repositorio debe implementar (contrato)
//using Microsoft.Data.SqlClient; // Librería para trabajar con SQL Server (SqlConnection)
using Microsoft.Extensions.Configuration; // Permite leer configuración (appsettings.json)

using System.Data;
using Npgsql;



//namespace DA.Repositorios // Namespace de la capa de acceso a datos (Data Access)
//{
//    // Clase que implementa la interfaz IRepositorioDapper
//    // Se encarga de crear y devolver la conexión a la base de datos
//    public class RepositorioDapper : IRepositorioDapper
//    {
//        private readonly IConfiguration _configuracion;
//        // Permite acceder a valores de configuración (como ConnectionStrings)

//        private readonly SqlConnection _conexionBaseDatos;
//        // Objeto que representa la conexión con SQL Server

//        // Constructor con inyección de dependencias
//        public RepositorioDapper(IConfiguration configuracion)
//        {
//            _configuracion = configuracion; // Se guarda la configuración

//            // Se crea la conexión usando la cadena definida en appsettings.json
//            _conexionBaseDatos =
//                new SqlConnection(_configuracion.GetConnectionString("BD"));
//        }

//        // Método que devuelve la conexión a la base de datos
//        public SqlConnection ObtenerRepositorio()
//        {
//            return _conexionBaseDatos; // Retorna la conexión ya configurada
//        }
//    }
//}
namespace DA.Repositorios
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuration;

        public RepositorioDapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection ObtenerRepositorio()
        {
            string connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            return new NpgsqlConnection(connectionString);
        }
    }
}