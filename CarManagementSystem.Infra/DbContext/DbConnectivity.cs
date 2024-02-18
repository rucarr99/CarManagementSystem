using Microsoft.Data.SqlClient;
using System.Data;

namespace CarManagementSystem.Infra.DbContext
{
    public class DbConnectivity : IDbConnectivity
    {
        private readonly string _connection;

        public DbConnectivity(string connection)
        {
            _connection = connection;
        }

        public SqlConnection DbConnection()
        {
            var sqlConnect = new SqlConnection(_connection);
            sqlConnect.Open();
            return sqlConnect;
        }

        public SqlCommand DbCommand(string strProcedure)
        {
            if (strProcedure == null) throw new ArgumentNullException(nameof(strProcedure));
            var sqlCmd = new SqlCommand(strProcedure, DbConnection()) { CommandType = CommandType.Text };
            return sqlCmd;
        }
    }
}
