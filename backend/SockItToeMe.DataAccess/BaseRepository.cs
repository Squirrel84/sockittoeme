using SockItToeMe.Core;
using System.Data;

namespace SockItToeMe.DataAccess
{
    public abstract class BaseRepository
    {
        IDbConnectionFactory _connectionFactory = null;

        public BaseRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected IDbConnection GetOpenConnection()
        {
            return _connectionFactory.CreateOpenConnection();
        }
    }
}