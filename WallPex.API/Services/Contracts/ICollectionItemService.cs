using WallPex.Models;

namespace WallPex.API.Services.Contracts;
public interface ICollectionItemService
{
    Task CreateCollectionItemAsync(CollectionItem collectionItem);
    Task DeleteAsync(int collectionItemId);
    Task<CollectionItem> GetCollectionItemByIdAsync(int collectionItemId);
    Task<IEnumerable<CollectionItem>> GetCollectionItemsByCollectionIdAsync(int collectionId);
}