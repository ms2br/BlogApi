using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Helpers
{
    public static class FileExtension
    {
        public static bool IsValidSize(this IFormFile file, float kb = 20000)
            => file.Length <= kb * 1024;

        public static bool IsCorrectType(this IFormFile file, string type = "image") => file.ContentType.Contains(type);


        public async static Task<string> SaveAsync(this IFormFile file, string path)
        {
            string fileName = Path.Combine(path, Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
            using (FileStream fs = File.Create(Path.Combine(PathConstants.RootPath, fileName)))
            {
                await file.CopyToAsync(fs);
            }
            return fileName;
        }
    }
}
