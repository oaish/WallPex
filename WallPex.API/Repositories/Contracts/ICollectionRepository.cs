using WallPex.Models;
using WallPex.Models.Dto;

namespace WallPex.API.Repositories.Contracts;
public interface ICollectionRepository
{
    void Create(Collection collection);
    void CreateWithItem(CollectionCreateWithItemDto collection);
    void Delete(int collectionId);
    IEnumerable<CollectionReadDto> GetAll(string userId);
    void Update(string collectionName, int collectionId);
}