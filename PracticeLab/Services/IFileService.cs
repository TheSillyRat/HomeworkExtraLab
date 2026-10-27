namespace PracticeLab.Services
{
    public interface IFileService
    {
        Task <string> SaveImageAsync(IFormFile file);
    }
}
