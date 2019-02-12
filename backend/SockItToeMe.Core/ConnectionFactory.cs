using System;
using System.Data;

namespace SockItToeMe.Core
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateOpenConnection();
    }

    public abstract class ConnectionFactory : IDbConnectionFactory
    {
        public ConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected string ConnectionString { get; }

        public abstract IDbConnection CreateOpenConnection();
    }
}
