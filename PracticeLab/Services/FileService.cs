namespace PracticeLab.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment env;
        public FileService(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) throw new ArgumentException("File is empty");

            var rootPath = env.WebRootPath ?? Path.Combine(env.ContentRootPath, "wwwroot");
            var uploadFolder = Path.Combine(rootPath, "uploads");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/uploads/{uniqueFileName}";
        }
    }
}
