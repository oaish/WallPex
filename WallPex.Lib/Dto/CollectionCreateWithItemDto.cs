namespace WallPex.Models.Dto;
public class CollectionCreateWithItemDto
{
    public int Id { get; set; }
    public string? CollectionName { get; set; }
    public bool CollectionType { get; set; }
    public string? UserId { get; set; }
    public int ItemId { get; set; }
    public string? ItemUrl { get; set; }
}
