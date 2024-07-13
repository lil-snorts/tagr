using System.IO;
using dotnet.Services;
using dotnet.Services.implementations;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    ImageService imageService = new ImageServiceImpl();

    [HttpPost]
    public IActionResult TestCreateImage()
    {
        var imagePath = "C:\\Users\\taylo\\Pictures\\gradpic.jpg";
        var imageBytes = System.IO.File.ReadAllBytes(imagePath);

        String encodedString = System.Convert.ToBase64String(imageBytes);
        imageService.CreateNewImage(1, "testOutput", encodedString, "JPG");
        return CreatedAtAction(nameof(TestCreateImage), encodedString, "teststr");
    }
}