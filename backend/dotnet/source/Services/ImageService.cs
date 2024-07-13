namespace dotnet.Services
{
    public interface ImageService
    {
        int CreateNewImage(int Id, String name, String content, String fileExtention);
    }
}
