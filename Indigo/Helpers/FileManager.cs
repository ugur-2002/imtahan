namespace Indigo.Helpers
{
    public class FileManager
    {
       
        public static string SaveFile(string rootPath, string folderName, IFormFile file)
        {
            string filename = file.FileName;
            filename = filename.Length > 64 ? filename.Substring(filename.Length - 64, 64) : filename;

            filename = Guid.NewGuid().ToString() + filename;

            string path = Path.Combine(rootPath, folderName, filename);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return filename;
        }


    }
}


