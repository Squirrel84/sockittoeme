using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SockItToeMe.Entities;

namespace SockItToeMe.DataAccess
{
    public interface IRepository
    {
    }

    public interface IRepository<E> : IRepository
    {
        Task<E> GetByIdAsync(int id);
    }
}
