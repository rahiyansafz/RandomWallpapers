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
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading photo: {ex.Message}");
        }
    }
}
