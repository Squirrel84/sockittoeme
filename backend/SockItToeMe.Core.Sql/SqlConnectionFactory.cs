using System.Data;
using System.Data.SqlClient;

namespace SockItToeMe.Core.Sql
{
    public class SqlConnectionFactory : ConnectionFactory
    {
        public SqlConnectionFactory(string connectionString) : base(connectionString)
        {

        }

        public override IDbConnection CreateOpenConnection()
        {
            var conn = new SqlConnection(this.ConnectionString);

            conn.Open();

            return conn;
        }
    }
}
