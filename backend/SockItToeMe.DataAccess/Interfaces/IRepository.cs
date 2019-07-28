using System.Threading.Tasks;

namespace SockItToeMe.DataAccess.Interfaces
{
    public interface IRepository
    {
    }

    public interface IRepository<E> : IRepository
    {
        Task<E> GetByIdAsync(int id);
    }
}
