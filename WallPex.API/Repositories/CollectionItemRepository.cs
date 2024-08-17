using Dapper;
using System.Data;
using WallPex.API.Repositories.Contracts;
using WallPex.Models;

namespace WallPex.API.Repositories;

public class CollectionItemRepository : ICollectionItemRepository
{
    private readonly IDbConnection _db;

    public CollectionItemRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<CollectionItem>> GetAllAsync(int collectionId)
    {
        var parameters = new { CollectionId = collectionId };
        return await _db.QueryAsync<CollectionItem>("spCollectionItems_ReadMany", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<CollectionItem?> GetByIdAsync(int collectionItemId)
    {
        var parameters = new { CollectionItemId = collectionItemId };
        return await _db.QueryFirstOrDefaultAsync<CollectionItem>("spCollectionItems_ReadOne", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CreateAsync(CollectionItem collectionItem)
    {
        var parameters = new
        {
            collectionItem.ItemId,
            collectionItem.ItemUrl,
            collectionItem.CollectionId
        };

        await _db.ExecuteAsync("spCollectionItems_Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteAsync(int collectionItemId)
    {
        var parameters = new
        {
            CollectionItemId = collectionItemId
        };

        await _db.ExecuteAsync("spCollectionItems_Delete", parameters, commandType: CommandType.StoredProcedure);
    }
}
