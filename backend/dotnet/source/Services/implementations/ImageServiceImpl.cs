using System.Drawing;
using System.Drawing.Imaging;
namespace dotnet.Services.Implementations;

public class ImageServiceImpl : ImageService
{
    private const string IMAGE_STORAGE_PATH = "..\\..\\image_storage";
    private string _imageSaveLocation;

    public ImageServiceImpl(string ImageSaveLocation)
    {
        if (ImageSaveLocation != null)
        {
            _imageSaveLocation = ImageSaveLocation;
        }
        else
        {
            _imageSaveLocation = IMAGE_STORAGE_PATH;
        }
    }

    public ImageServiceImpl()
    {
        _imageSaveLocation = IMAGE_STORAGE_PATH;
    }

    public String CreateNewImage(string name, string content, String fileExtention)
    {
        if (Directory.GetDirectories(_imageSaveLocation).Length == 0)
        {
            System.IO.Directory.CreateDirectory(_imageSaveLocation);
            System.Console.WriteLine("Created Dir");
        }
        else
        {
            System.Console.WriteLine($"{_imageSaveLocation} exists");
        }

        byte[] imageBytes = Convert.FromBase64String(content);
        using (MemoryStream memoryStream = new MemoryStream(imageBytes))
        {
            using (Image image = Image.FromStream(memoryStream))
            {
                String filePath = $"{IMAGE_STORAGE_PATH}/{name}.{fileExtention}";

                ImageFormat format = GetImageFormat(fileExtention);

                try
                {
                    image.Save(filePath, format);
                    System.Console.WriteLine("Saved image");
                }
                catch (System.Exception exception)
                {
                    System.Console.WriteLine(exception.Data);
                    throw;
                }
            }
        }
        return name;
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

