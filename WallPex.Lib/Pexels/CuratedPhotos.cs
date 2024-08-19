namespace WallPex.Models.Pexels;

public class CuratedPhotos
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public List<Photo> Photos { get; set; }
    public int TotalResults { get; set; }
    public string NextPage { get; set; }
}
