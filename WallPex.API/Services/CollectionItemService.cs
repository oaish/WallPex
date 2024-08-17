using WallPex.API.Repositories.Contracts;
using WallPex.API.Services.Contracts;
using WallPex.Models;

namespace WallPex.API.Services;

public class CollectionItemService : ICollectionItemService
{
    private readonly ICollectionItemRepository _collectionItemRepository;

    public CollectionItemService(ICollectionItemRepository collectionItemRepository)
    {
        _collectionItemRepository = collectionItemRepository;
    }

    public async Task<IEnumerable<CollectionItem>> GetCollectionItemsByCollectionIdAsync(int collectionId)
    {
        return await _collectionItemRepository.GetAllAsync(collectionId);
    }

    public async Task<CollectionItem> GetCollectionItemByIdAsync(int collectionItemId)
    {
        return await _collectionItemRepository.GetByIdAsync(collectionItemId);
    }

    public async Task CreateCollectionItemAsync(CollectionItem collectionItem)
    {
        await _collectionItemRepository.CreateAsync(collectionItem);
    }

    public async Task DeleteAsync(int collectionItemId)
    {
        await _collectionItemRepository.DeleteAsync(collectionItemId);
    }
}
