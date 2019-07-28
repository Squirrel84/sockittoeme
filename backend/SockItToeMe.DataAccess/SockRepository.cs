using Dapper;
using SockItToeMe.Core;
using SockItToeMe.DataAccess.Interfaces;
using SockItToeMe.Entities;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SockItToeMe.DataAccess
{
    public interface ISockRepository : IRepository<SockEntity>
    {
    }

    public class SockRepository : BaseRepository, ISockRepository
    {
        public SockRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<SockEntity> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Sock WHERE Id = @id";

            using (IDbConnection conn = this.GetOpenConnection())
            {
                return (await conn.QueryAsync<SockEntity>(sql, new { id })).FirstOrDefault();
            }
        }
    }
}
