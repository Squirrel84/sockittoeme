using Dapper;
using SockItToeMe.Core;
using SockItToeMe.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SockItToeMe.DataAccess
{
    public interface IMaterialRepository : IRepository<MaterialEntity>    
    {

    }

    public class MaterialRepository : BaseRepository, IMaterialRepository
    {
        public MaterialRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<MaterialEntity> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Material WHERE Id = @id";

            using (IDbConnection conn = this.GetOpenConnection())
            {
                return (await conn.QueryAsync<MaterialEntity>(sql, new { id })).FirstOrDefault();
            }
        }
    }
}
