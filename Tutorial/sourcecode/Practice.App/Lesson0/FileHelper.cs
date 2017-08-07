using System.IO;

namespace Practice.App.Lesson0
{
    public class FileHelper
    {
        public static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
