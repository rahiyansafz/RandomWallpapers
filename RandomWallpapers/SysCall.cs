using System.Runtime.InteropServices;

namespace RandomWallpapers;
public class SysCall
{
    const int _sPI_SETDESKWALLPAPER = 20;
    const int _sPIF_UPDATEINIFILE = 0x01;
    const int _sPIF_SENDWININICHANGE = 0x02;

    public enum ProcessDpiAwareness
    {
        ProcessDpiUnaware = 0,
        ProcessSystemDpiAware = 1,
        ProcessPerMonitorDpiAware = 2
    }

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    [DllImport("shcore.dll")]
    private static extern int SetProcessDpiAwareness(ProcessDpiAwareness Dpi);

    // Setting the current process as dots per inch (dpi) aware to get best resutls.
    public static bool EnableDpiAwareness()
    {
        try
        {
            if (Environment.OSVersion.Version.Major < 6)
                return false;
            SetProcessDpiAwareness(ProcessDpiAwareness.ProcessPerMonitorDpiAware);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public static bool SetDesktopWallpaper(string wallpaperFilePath)
    {
        try
        {
            SystemParametersInfo(_sPI_SETDESKWALLPAPER, 0, wallpaperFilePath,
                _sPIF_UPDATEINIFILE | _sPIF_SENDWININICHANGE);
            return true;
        }
        catch
        {
            return false;
        }
    }
}