using Microsoft.Extensions.Caching.Memory;
using SockItToeMe.Application.Base;
using SockItToeMe.DataAccess;
using SockItToeMe.Models;
using System.Threading.Tasks;

namespace SockItToeMe.Application
{
    public interface ISizeProvider : IProvider<SockProfileSizeModel>
    {

    }

    public class SizeProvider : BaseCacheProvider<SockProfileSizeModel>, ISizeProvider
    {
        public override string cache_key => "size_cache_key";

        private readonly IMaterialRepository _repository;

        public SizeProvider(IMemoryCache memoryCache, IMaterialRepository repository) : base(memoryCache)
        {
            _repository = repository;
        }

        public async Task<SockProfileSizeModel> GetByIdAsync(int id)
        {
            SockProfileSizeModel model = null;

            if (!this.TryGetFromCache(id, out model))
            {
                var entity = await _repository.GetByIdAsync(id);

                if (entity != null)
                {
                    model = new SockProfileSizeModel(entity.Id, entity.Description);

                    this.AddToCache(model);

                    return model;
                }

                return null;
            }

            return model;
        }
    }
}