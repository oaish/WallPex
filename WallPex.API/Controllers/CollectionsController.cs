using Microsoft.AspNetCore.Mvc;
using WallPex.API.Services.Contracts;
using WallPex.Models;
using WallPex.Models.Dto;

namespace WallPex.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CollectionsController : ControllerBase
{
    private readonly ICollectionService _collection;
    private readonly ICollectionItemService _collectionItem;

    public CollectionsController(ICollectionService collection, ICollectionItemService collectionItem)
    {
        _collection = collection;
        _collectionItem = collectionItem;
    }

    [HttpGet("{collectionId}")]
    public async Task<IActionResult> GetCollectionById(int collectionId)
    {
        var collection = await _collection.GetCollectionByIdAsync(collectionId);

        return collection != null ? Ok(collection) : NotFound($"No collections found for this collectionId: {collectionId}");
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetCollectionsByUserId(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            BadRequest("User Id is null or empty");
        }

        var collections = await _collection.GetCollectionsByUserIdAsync(userId);

        return collections != null ? Ok(collections) : NotFound($"No collections found for this userId: {userId}");
    }

    [HttpPost("create/empty")]
    public async Task<IActionResult> CreateEmptyCollection([FromBody] Collection collection)
    {
        if (collection == null)
        {
            return BadRequest("Collection object is null");
        }

        await _collection.CreateCollectionAsync(collection);

        return Created();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCollection([FromBody] CollectionCreateWithItemDto collection)
    {
        if (collection == null)
        {
            return BadRequest("Collection object is null");
        }

        await _collection.CreateCollectionWithItemAsync(collection);

        return Created();
    }

    [HttpPatch("update")]
    public async Task<IActionResult> ChangeCollectionName([FromQuery] string collectionName, [FromQuery] int collectionId)
    {
        var collection = await _collection.GetCollectionByIdAsync(collectionId);
        if (collection == null)
        {
            return NotFound("Collection by the given id is not present");
        }

        await _collection.UpdateAsync(collectionName, collectionId);

        return NoContent();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> RemoveCollection([FromQuery] int collectionId)
    {
        await _collection.DeleteAsync(collectionId);

        return NoContent();
    }

    [HttpGet("items")]
    public async Task<IActionResult> GetCollectionItemsByCollectionId(int collectionId)
    {
        var collectionItems = await _collectionItem.GetCollectionItemsByCollectionIdAsync(collectionId);
        return collectionItems == null ? NotFound("Collection is empty") : Ok(collectionItems);
    }

    [HttpGet("item/id")]
    public async Task<IActionResult> GetCollectionItemById(int collectionItemId)
    {
        var collectionItem = await _collectionItem.GetCollectionItemByIdAsync(collectionItemId);
        return collectionItem == null ? NotFound("Collection Item is not present") : Ok(collectionItem);
    }

    [HttpPost("item/add")]
    public async Task<IActionResult> AddItemToCollection([FromBody] CollectionItem collectionItem)
    {
        if (collectionItem == null)
        {
            return BadRequest("Collection item is null");
        }

        await _collectionItem.CreateCollectionItemAsync(collectionItem);
        return Created();
    }

    [HttpDelete("item/delete/{collectionItemId}")]
    public async Task<IActionResult> RemoveItemFromCollection(int collectionItemId)
    {
        await _collectionItem.DeleteAsync(collectionItemId);
        return NoContent();
    }
}
