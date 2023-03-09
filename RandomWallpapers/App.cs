using RandomWallpapers.ImageProvider;

namespace RandomWallpapers;
public class App
{
    private static IImageProvider? _provider;
    private static bool TestConnection()
    {
        try
        {
            System.Net.NetworkInformation.Ping pingSender = new();
            System.Net.NetworkInformation.PingReply reply = pingSender.Send("www.google.com");
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                return true;
        }
        catch (Exception) { }
        return false;
    }

    public static async Task Run()
    {
        if (!OperatingSystem.IsWindows())
        {
            Console.WriteLine("Sorry, Only supporting Windows now.");
            return;
        }

        if (Settings.Online && TestConnection() == false)
        {
            Console.WriteLine("Please Check Your Internet Connection.");
            return;
        }

        if (Settings.Online)
            _provider = new OnlineImageProvider();
        else
            _provider = new OfflineImageProvider();
        _ = new ScreenPainter(Settings.Style);
        int everyNMinutes = int.Parse(Settings.EveryNMinutes) * 60 * 1000;

        while (true)
        {
            string? imgPath = await _provider.GetImage();
            if (string.IsNullOrEmpty(imgPath))
            {
                Console.WriteLine("Error : Couldn't Get Image Path.");
                return;
            }
            ScreenPainter.SetWallpaperImage(imgPath);
            await Task.Delay(everyNMinutes);
        }
    }
}
