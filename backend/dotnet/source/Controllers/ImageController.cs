using System.IO;
using dotnet.Services;
using dotnet.Services.implementations;
using Microsoft.AspNetCore.Mvc;
using OpenApi.Controllers;
using OpenApi.Models;
using OpenApi.Attributes;
using System.ComponentModel.DataAnnotations;
namespace dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ImagesApiController
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

    [HttpDelete]
    [Route("/image/{imageId}")]
    [ValidateModelState]
    override public IActionResult ImageImageIdDelete(
        [FromRoute(Name = "imageId")][Required][RegularExpression("$[A-z0-9]+^")] 
        string imageId) 
    {
        return CreatedAtAction(nameof(TestCreateImage), "", "teststr");
    }

    [HttpGet]
    [Route("/image/{imageId}")]
    [ValidateModelState]
    [ProducesResponseType(statusCode: 200, type: typeof(ImagesResponse))]
    override public IActionResult ImageImageIdGet(
        [FromRoute(Name = "imageId")][Required] 
        string imageId) 
    {
        return CreatedAtAction(nameof(TestCreateImage), "", "teststr");
    }

    [HttpPost]
    [Route("/image")]
    [Consumes("application/json")]
    [ValidateModelState]
    [ProducesResponseType(statusCode: 201, type: typeof(ImagePost201Response))]
    override public IActionResult ImagePost(
        [FromBody] ImageUploadRequest imageUploadRequest)
    {
        return CreatedAtAction(nameof(TestCreateImage), "", "teststr");
    }

    [HttpGet]
    [Route("/images")]
    [ValidateModelState]
    [ProducesResponseType(statusCode: 200, type: typeof(ImagesResponse))]
    override public IActionResult ImagesGet(
        [FromQuery(Name = "unionFind")]
        [Required()]
        bool unionFind,
        [FromQuery(Name = "retrievalLimit")]
        [Range(1, 40)]
        decimal? retrievalLimit,
        [FromQuery(Name = "page")]
        decimal? page,
        [FromQuery(Name = "labels")]
        List<string> labels)
    {
        return CreatedAtAction(nameof(TestCreateImage), "", "teststr");
    }
}
