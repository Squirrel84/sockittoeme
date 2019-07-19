using SockItToeMe.Application.Base;
using SockItToeMe.DataAccess;
using SockItToeMe.Entities;
using SockItToeMe.Models;
using System.Drawing;
using System.Threading.Tasks;

namespace SockItToeMe.Application
{
    public interface ISockProvider : IProvider<SockProfileModel>
    {
        
    }

    public class SockProvider : ISockProvider
    {
        private readonly ISockRepository _sockRepository;
        private readonly IMaterialProvider _materialProvider;
        private readonly IThicknessProvider _thicknessProvider;
        private readonly ISizeProvider _sizeProvider;

        public SockProvider(ISockRepository sockRepository, IMaterialProvider materialProvider, IThicknessProvider thicknessProvider, ISizeProvider sizeProvider)
        {
            _sockRepository = sockRepository;
            _materialProvider = materialProvider;
            _thicknessProvider = thicknessProvider;
            _sizeProvider = sizeProvider;
        }

        public async Task<SockProfileModel> GetByIdAsync(int id)
        {
            var entity = await _sockRepository.GetByIdAsync(id);

            if (entity != null)
            {
                var material = await _materialProvider.GetByIdAsync(entity.MaterialId);
                var thickness = await _thicknessProvider.GetByIdAsync(entity.ThicknessId);
                var size = await _sizeProvider.GetByIdAsync(entity.SizeId);

                return new SockProfileModel()
                {
                    Description = entity.Description,
                    Colour = entity.Colour,
                    Size = size,
                    Material = material,
                    Thickness = thickness,
                };
            }

            return null;
        }
    }
}