using WallPex.Models;
using WallPex.Models.Dto;

namespace WallPex.API.Services.Contracts;
public interface ICollectionService
{
    Task CreateCollectionAsync(Collection collection);
    Task CreateCollectionWithItemAsync(CollectionCreateWithItemDto collection);
    Task DeleteAsync(int collectionId);
    Task<CollectionReadDto?> GetCollectionByIdAsync(int collectionId);
    Task<IEnumerable<CollectionReadDto>> GetCollectionsByUserIdAsync(string userId);
    Task UpdateAsync(string collectionName, int collectionId);
}