//using Microsoft.Data.SqlClient;
//using Npgsql;

//namespace Abstracciones.Interfaces.DA
//{
//    public interface IRepositorioDapper
//    {
//        NpgsqlConnection ObtenerRepositorio();
//    }
//}

using System.Data;

namespace Abstracciones.Interfaces.DA
{
    public interface IRepositorioDapper
    {
        IDbConnection ObtenerRepositorio();
    }
}
