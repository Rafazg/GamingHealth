using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace GamingHealth.Infrastructure.Data
{
    public class OracleDbContext
    {
        private readonly string _connectionString;

        public OracleDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
            => new OracleConnection(_connectionString);
    }
}