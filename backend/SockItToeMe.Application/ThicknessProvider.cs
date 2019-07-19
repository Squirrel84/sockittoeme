using Microsoft.Extensions.Caching.Memory;
using SockItToeMe.Application.Base;
using SockItToeMe.DataAccess;
using SockItToeMe.Models;
using System.Threading.Tasks;

namespace SockItToeMe.Application
{
    public interface IThicknessProvider : IProvider<SockProfileThicknessModel>
    {

    }

    public class ThicknessProvider : BaseCacheProvider<SockProfileThicknessModel>, IThicknessProvider
    {
        public override string cache_key => "thickness_cache_key";

        private readonly IThicknessRepository _repository;

        public ThicknessProvider(IMemoryCache memoryCache, IThicknessRepository repository) : base(memoryCache)
        {
            _repository = repository;
        }

        public async Task<SockProfileThicknessModel> GetByIdAsync(int id)
        {
            SockProfileThicknessModel model = null;

            if (!this.TryGetFromCache(id, out model))
            {
                var entity = await _repository.GetByIdAsync(id);

                if (entity != null)
                {
                    model = new SockProfileThicknessModel(entity.Id, entity.Description);

                    this.AddToCache(model);

                    return model;
                }

                return null;
            }

            return model;
        }
    }
}