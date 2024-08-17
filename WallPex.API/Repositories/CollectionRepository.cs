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

    public IEnumerable<CollectionReadDto> GetAll(string userId)
    {
        var parameters = new { UserId = userId };

        return _db.Query<CollectionReadDto>("spCollections_Read", parameters, commandType: CommandType.StoredProcedure);
    }

    public void Create(Collection collection)
    {
        var parameters = new
        {
            collection.CollectionName,
            collection.CollectionType,
            collection.UserId
        };

        _db.Execute("spCollections_Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public void CreateWithItem(CollectionCreateWithItemDto collection)
    {
        var parameters = new
        {
            collection.CollectionName,
            collection.CollectionType,
            collection.UserId,
            collection.ItemId,
            collection.ItemUrl
        };

        _db.Execute("spCollections_CreateWithItem", parameters, commandType: CommandType.StoredProcedure);
    }

    public void Update(string collectionName, int collectionId)
    {
        var parameters = new
        {
            CollectionName = collectionName,
            CollectionId = collectionId
        };

        _db.Execute("spCollections_Update", parameters, commandType: CommandType.StoredProcedure);
    }

    public void Delete(int collectionId)
    {
        var parameters = new
        {
            CollectionId = collectionId
        };

        _db.Execute("spCollections_Delete", parameters, commandType: CommandType.StoredProcedure);
    }
}
