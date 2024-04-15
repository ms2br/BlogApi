using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Helpers
{
    public static class FileExtension
    {
        public static bool IsValidSize(this IFormFile file, float kb = 20000)
            => file.Length <= kb * 1024;

        public static bool IsCorrectType(this IFormFile file, string type = "image") => file.ContentType.Contains(type);

        public async static Task<(string, string)> SaveAsync(this IFormFile file, string path)
        {
            string fileName = Guid.NewGuid().ToString();
            string filePath = Path.Combine(PathConstants.RootPath, path, fileName + Path.GetExtension(file.FileName));
            using (FileStream fs = File.Create(filePath))
            {
                await file.CopyToAsync(fs);
            }
            return (filePath, fileName);
        }

        public async static Task UpdateAsync(this IFormFile file, string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception();
            using (FileStream fs = File.Create(filePath))
                await file.CopyToAsync(fs);
        }

        public static void FileRemove(this string filePath)
        {
            File.Delete(filePath);
        }
    }
}
