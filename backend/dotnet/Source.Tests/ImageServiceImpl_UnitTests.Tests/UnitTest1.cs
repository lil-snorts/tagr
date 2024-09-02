using System.Reflection.Metadata;
using dotnet.Services.Implementations;
using Xunit;

namespace ImageServiceImpl_Tests.Tests;

public class UnitTest1 : IDisposable
{
    private const string TEST_IMAGE_SAVE_LOCATION = "../../test_image_location";
    ImageServiceImpl imageService = new ImageServiceImpl(TEST_IMAGE_SAVE_LOCATION);


    private void cleanUp()
    {
        Directory.Delete(TEST_IMAGE_SAVE_LOCATION);
    }

    [Fact]
    public void ThatSavingAnImageReturnsTheExpectedImageId()
    {
        string expectedImageId = "hello";
        var output = imageService.CreateNewImage(expectedImageId, "xxx", "jpg");

        Assert.Equal(expectedImageId, output);

        cleanUp();
    }

    [Fact]
    public void ThatAttempingToSaveAnImageWithADuplicateImageIdReturnsAnError()
    {

        string expectedImageId = "hello";
        var output = imageService.CreateNewImage(expectedImageId, "xxx", "jpg");

        // Save over it
        Assert.Throws<ArgumentNullException>(
            () => imageService.CreateNewImage(expectedImageId, "any", "png"));

        cleanUp();
    }

    [Fact]
    public void ThatImageDirectoryIsCreatedIfItDoesntExist()
    {

        cleanUp();
    }

    [Fact]
    public void WhenTheImageDirectoryExistsItIsntOverWritten()
    {

        cleanUp();
    }

    [Fact]
    public void ThatUnrecognisedImageFormatThrowsException()
    {
        Assert.Throws<ArgumentNullException>(
            () => imageService.CreateNewImage("any", "any", "fake"));
        cleanUp();
    }

    public void Dispose()
    {
        cleanUp();
    }
}