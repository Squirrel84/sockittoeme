using Dapper;
using SockItToeMe.Core;
using SockItToeMe.DataAccess.Interfaces;
using SockItToeMe.Entities;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SockItToeMe.DataAccess
{
    public interface ISizeRepository : IRepository<SizeEntity>    
    {

    }

    public class SizeRepository : BaseRepository, ISizeRepository
    {
        public SizeRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<SizeEntity> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Size WHERE Id = @id";

            using (IDbConnection conn = this.GetOpenConnection())
            {
                return (await conn.QueryAsync<SizeEntity>(sql, new { id })).FirstOrDefault();
            }
        }
    }
}
