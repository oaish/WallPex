using Dapper;
using System.Data;
using WallPex.API.Repositories.Contracts;
using WallPex.Models;
using WallPex.Models.Dto;

namespace WallPex.API.Repositories;

public class CollectionRepository : ICollectionRepository
{
    private readonly IDbConnection _db;

    public CollectionRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<CollectionReadDto>> GetAllAsync(string userId)
    {
        var parameters = new { UserId = userId };
        return await _db.QueryAsync<CollectionReadDto>("spCollections_ReadMany", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<CollectionReadDto?> GetByIdAsync(int collectionId)
    {
        var parameters = new { CollectionId = collectionId };
        return await _db.QueryFirstOrDefaultAsync<CollectionReadDto>("spCollections_ReadOne", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CreateAsync(Collection collection)
    {
        var parameters = new
        {
            collection.CollectionName,
            collection.CollectionType,
            collection.UserId
        };

        await _db.ExecuteAsync("spCollections_Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CreateWithItemAsync(CollectionCreateWithItemDto collection)
    {
        var parameters = new
        {
            collection.CollectionName,
            collection.CollectionType,
            collection.UserId,
            collection.ItemId,
            collection.ItemUrl
        };

        await _db.ExecuteAsync("spCollections_CreateWithItem", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAsync(string collectionName, int collectionId)
    {
        var parameters = new
        {
            CollectionName = collectionName,
            CollectionId = collectionId
        };

        await _db.ExecuteAsync("spCollections_Update", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteAsync(int collectionId)
    {
        var parameters = new
        {
            CollectionId = collectionId
        };

        await _db.ExecuteAsync("spCollections_Delete", parameters, commandType: CommandType.StoredProcedure);
    }
}
