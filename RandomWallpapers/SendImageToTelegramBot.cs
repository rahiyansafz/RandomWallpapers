using SixLabors.ImageSharp.Formats.Jpeg;

using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace RandomWallpapers;
internal class SendImageToTelegramBot
{
    internal static async Task SendFile(string? filePath)
    {
        var botClient = new TelegramBotClient(Settings.BotClientId);

        using CancellationTokenSource cts = new();

        var chatId = Settings.ChatId;

        //string directoryPath = @"C:\AwesomeWallpapers\Random";

        //// Set the search pattern to find all image files (modify as needed)
        //string searchPattern = "*.jpeg";

        //// Get the paths of all image files in the directory
        //string[] filepaths = Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);

        //Console.WriteLine($"Found {filepaths.Length} files matching the pattern in the {directoryPath} directory.");

        //// Loop through the file paths and print each one to the console
        //foreach (string filepath in filepaths)
        //    Console.WriteLine("filePaths: " + filepath);

        //// Create a new List<string> to store the image paths
        //List<string> imagesPath = new();

        //// Loop through the file paths and add them to the imagesPath list
        //foreach (string filepath in filepaths)
        //    imagesPath.Add(filepath);

        // Loop through the image paths and print each one to the console
        //foreach (string filePath in imagesPath)
        //{
        try
        {
            if (filePath is not null)
            {
                Console.WriteLine(filePath);
                var extension = Path.GetExtension(filePath);
                var fileName = Guid.NewGuid().ToString() + extension;

                using var image = SixLabors.ImageSharp.Image.Load(filePath);
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(1024, 1024),
                    Mode = ResizeMode.Max
                }));

                using var stream = new MemoryStream();
                image.Save(stream, new JpegEncoder());
                stream.Position = 0;

                var fileToSend = new InputOnlineFile(stream, fileName);

                var photoMessage = await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: fileToSend,
                    parseMode: ParseMode.Html,
                    cancellationToken: cts.Token);

                Console.WriteLine($"Photo {fileName} uploaded successfully.");
                ////imagesPath.Remove(filePath);
                //Console.WriteLine($"Removing {filePath} from the list");
                //Console.WriteLine($"Remaining files: {filepaths.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading photo: {ex.Message}");
        }
        //}
    }
}
