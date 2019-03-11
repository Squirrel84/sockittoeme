using SockItToeMe.Application.Base;
using SockItToeMe.DataAccess;
using SockItToeMe.Entities;
using SockItToeMe.Models;
using System.Threading.Tasks;

namespace SockItToeMe.Application
{
    public interface ISockProvider : IProvider<SockProfileModel>
    {
        
    }

    public class SockProvider : ISockProvider
    {
        private readonly ISockRepository _sockRepository;

        public SockProvider(ISockRepository sockRepository)
        {
            _sockRepository = sockRepository;
        }

        public async Task<SockProfileModel> GetByIdAsync(int id)
        {
            var entity = new SockEntity() { Colour = "Black", Description = "Big Black One", Material = "Cotton", Size = "Big", SockId = id, Thickness = "Thermal" }; //await _sockRepository.GetSockByIdAsync(id);

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