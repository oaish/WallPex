using WallPex.API.Repositories.Contracts;
using WallPex.API.Services.Contracts;
using WallPex.Models;
using WallPex.Models.Dto;

namespace WallPex.API.Services;

public class CollectionService : ICollectionService
{
    private readonly ICollectionRepository _collectionRepository;

    public CollectionService(ICollectionRepository collectionRepository)
    {
        _collectionRepository = collectionRepository;
    }

    public async Task<IEnumerable<CollectionReadDto>> GetCollectionsByUserIdAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            throw new ArgumentNullException(nameof(userId));
        }

        return await _collectionRepository.GetAllAsync(userId);
    }

    public async Task<CollectionReadDto?> GetCollectionByIdAsync(int collectionId)
    {
        return await _collectionRepository.GetByIdAsync(collectionId);
    }

    public async Task CreateCollectionAsync(Collection collection)
    {
        await _collectionRepository.CreateAsync(collection);
    }

    public async Task CreateCollectionWithItemAsync(CollectionCreateWithItemDto collection)
    {
        await _collectionRepository.CreateWithItemAsync(collection);
    }

    public async Task UpdateAsync(string collectionName, int collectionId)
    {
        await _collectionRepository.UpdateAsync(collectionName, collectionId);
    }

    public async Task DeleteAsync(int collectionId)
    {
        await _collectionRepository.DeleteAsync(collectionId);
    }
}
