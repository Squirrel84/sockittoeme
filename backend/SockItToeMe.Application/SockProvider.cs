using SockItToeMe.DataAccess;
using SockItToeMe.Models;
using System.Threading.Tasks;

namespace SockItToeMe.Application
{
    public interface ISockProvider
    {
        Task<SockProfileModel> GetSockByIdAsync(int id);
    }

    public class SockProvider : ISockProvider
    {
        private readonly ISockRepository _sockRepository;

        public SockProvider(ISockRepository sockRepository)
        {
            _sockRepository = sockRepository;
        }

        public async Task<SockProfileModel> GetSockByIdAsync(int id)
        {
            var entity = await _sockRepository.GetSockByIdAsync(id);

            if (entity != null)
            {
                return new SockProfileModel()
                {
                    Description = entity.Description,
                    Colour = entity.Colour,
                    Material = entity.Material,
                    Thickness = entity.Thickness
                };
            }

            return null;
        }
    }
}