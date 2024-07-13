using System.Drawing;
using System.Drawing.Imaging;
namespace dotnet.Services.implementations;

public class ImageServiceImpl : ImageService
{
    private const string IMAGE_STORAGE_PATH = "..\\..\\image_storage";

    public int CreateNewImage(int Id, string name, string content, String fileExtention)
    {
        byte[] imageBytes = Convert.FromBase64String(content);
        System.IO.Directory.CreateDirectory(IMAGE_STORAGE_PATH);
        System.Console.WriteLine("Created Dir");


        using (MemoryStream memoryStream = new MemoryStream(imageBytes))
        {
            using (Image image = Image.FromStream(memoryStream))
            {
                String filePath = $"{IMAGE_STORAGE_PATH}/{name}.{fileExtention}";

                ImageFormat format = GetImageFormat(fileExtention);

                image.Save(filePath, format);
                System.Console.WriteLine("Saved image");
            }
        }
        return 1;
    }

    private static ImageFormat GetImageFormat(string format)
    {
        return format.ToLower() switch
        {
            "jpg" => ImageFormat.Jpeg,
            "jpeg" => ImageFormat.Jpeg,
            "png" => ImageFormat.Png,
            "bmp" => ImageFormat.Bmp,
            "gif" => ImageFormat.Gif,
            _ => throw new ArgumentException("Invalid image format", nameof(format)),
        };
    }
}

