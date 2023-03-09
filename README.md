# RandomWallpapers

RandomWallpapers is a simple project that retrieves random wallpapers from Unsplash's API and sets them as your desktop background wallpaper. It can be used both online and offline and is highly configurable via the Settings class.

## Getting Started

### Prerequisites

-   [.NET 7](https://dotnet.microsoft.com/download)

### Installation

1.  Clone the repository:
    `https://github.com/rahiyansafz/RandomWallpapersCLI.git` 
2.  Open the solution in Visual Studio.
3.  Modify the Settings class to suit your preferences.
4.  Build the solution.

### Usage

1.  Run the executable.
2.  The application will automatically retrieve random wallpapers from Unsplash's API and set them as your desktop background wallpaper.
3.  By default, the wallpaper will be changed every 1 minute. This can be configured in the Settings class.

## Configuration

The Settings class can be used to configure the behavior of the application. Here are the available options:

-   `Online`: A boolean value that determines whether the application should retrieve wallpapers from Unsplash's API online. Default is `true`.
-   `RandomImage`: A boolean value that determines whether the application should retrieve a random image from the API. Default is `true`.
-   `EveryNMinutes`: A string that specifies how often the wallpaper should be changed, in minutes. Default is `"1"`.
-   `Style`: An enumeration that specifies how the wallpaper should be displayed. Default is `WallpaperStyle.Span`.
-   `AppDirectory`: A string that specifies the directory where wallpapers will be stored. Default is `"C:\\AwesomeWallpapers"`.
-   `OfflineDirectory`: A string that specifies the directory where wallpapers will be stored when the application is run offline. Default is `"C:\\AwesomeWallpapers\\Offline"`.
-   `QueryString`: A string that specifies the search terms used to retrieve wallpapers from Unsplash's API. Default is `"Lifestyle, Passion, Career, Programming, Coding, City, Music, Film, Athletics, Interior Design, Living Room, Bedroom, Office, City, Night City, Arts & Culture, People, Food & Drink"`.
-   `BaseURL`: A string that specifies the base URL of Unsplash's API. Default is `"https://api.unsplash.com/"`.
-   `AccessKey`: A string that specifies your Unsplash API access key. **This should be kept private**. Default is `"YOUR_API_KEY"`.
-   `Secretkey`: A string that specifies your Unsplash API secret key. Default is an empty string.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
