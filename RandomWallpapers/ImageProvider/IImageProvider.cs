namespace RandomWallpapers.ImageProvider;
public interface IImageProvider
{
    Task<string?> GetImage();
}