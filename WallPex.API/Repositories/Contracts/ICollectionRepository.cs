using WallPex.Models;
using WallPex.Models.Dto;

namespace WallPex.API.Repositories.Contracts;
public interface ICollectionRepository
{
    Task CreateAsync(Collection collection);
    Task CreateWithItemAsync(CollectionCreateWithItemDto collection);
    Task DeleteAsync(int collectionId);
    Task<IEnumerable<CollectionReadDto>> GetAllAsync(string userId);
    Task<CollectionReadDto?> GetByIdAsync(int collectionId);
    Task UpdateAsync(string collectionName, int collectionId);
}