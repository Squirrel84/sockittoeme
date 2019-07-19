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
    public interface IThicknessRepository : IRepository<ThicknessEntity>    
    {

    }

    public class ThicknessRepository : BaseRepository, IThicknessRepository
    {
        public ThicknessRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<ThicknessEntity> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Thickness WHERE Id = @id";

            using (IDbConnection conn = this.GetOpenConnection())
            {
                return (await conn.QueryAsync<ThicknessEntity>(sql, new { id })).FirstOrDefault();
            }
        }
    }
}
