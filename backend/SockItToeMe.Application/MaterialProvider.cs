using Microsoft.Extensions.Caching.Memory;
using SockItToeMe.Application.Base;
using SockItToeMe.DataAccess;
using SockItToeMe.Models;
using System.Threading.Tasks;

namespace SockItToeMe.Application
{
    public interface IMaterialProvider : IProvider<SockProfileMaterialModel>
    {
        
    }

    public class MaterialProvider : BaseCacheProvider<SockProfileMaterialModel>, IMaterialProvider
    {
        public override string cache_key => "material_cache_key";

        private readonly IMaterialRepository _repository;

        public MaterialProvider(IMemoryCache memoryCache, IMaterialRepository repository) : base(memoryCache)
        {
            _repository = repository;
        }

        public async Task<SockProfileMaterialModel> GetByIdAsync(int id)
        {
            SockProfileMaterialModel model = null;

            if (!this.TryGetFromCache(id, out model))
            {
                var entity = await _repository.GetByIdAsync(id);

                if (entity != null)
                {
                    model = new SockProfileMaterialModel(entity.Id, entity.Description);

                    this.AddToCache(model);

                    return model;
                }

                return null;
            }
            
            return model;
        }
    }
}