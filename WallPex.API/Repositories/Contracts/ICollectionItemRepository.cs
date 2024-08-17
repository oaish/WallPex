using WallPex.Models;

namespace WallPex.API.Repositories.Contracts;
public interface ICollectionItemRepository
{
    Task CreateAsync(CollectionItem collectionItem);
    Task DeleteAsync(int collectionItemId);
    Task<IEnumerable<CollectionItem>> GetAllAsync(int collectionId);
    Task<CollectionItem?> GetByIdAsync(int collectionItemId);
}