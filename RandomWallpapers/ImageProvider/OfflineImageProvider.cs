using System.Text.RegularExpressions;

namespace RandomWallpapers.ImageProvider;

partial class OfflineImageProvider : IImageProvider
{
    public static string? GetOneRandomly(string? path = null)
    {
        path ??= Settings.OfflineDirectory;

        if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            return null;

        // regex to filter non image files.
        var wallNameRegex = WallpaperNameRegex();
        var filesList = Directory.GetFiles(path).Where(x => wallNameRegex.IsMatch(x)).ToList();
        if (filesList.Count < 0)
        {
            Console.WriteLine("ERROR : Directory specified doesn't contain images.");
            return null;
        }

        // filter non image files.
        IEnumerable<string> wallsList =
            from wallFilePath in filesList
            let resExp = wallNameRegex.Match(wallFilePath).Groups[0].Value
            select resExp;

        // choose and return one randomly.
        var randgen = new Random();
        int idx = randgen.Next(0, filesList.Count - 1);
        var chosenImage = wallsList.ElementAt(idx);
        return chosenImage;
    }

    public Task<string?> GetImage()
    {
        return Task.FromResult(
            GetOneRandomly()
            );
    }

    [GeneratedRegex("[^\\s]+(.*?)\\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$")]
    private static partial Regex WallpaperNameRegex();
}