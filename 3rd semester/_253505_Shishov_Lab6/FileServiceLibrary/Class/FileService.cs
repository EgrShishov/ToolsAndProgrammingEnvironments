using System.Text.Json;
using _253505_Shishov_Lab6.Lib.Interfaces;

namespace _253505_Shishov_Lab6.Lib.Class
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public FileService() { }
        public IEnumerable<T> ReadFile(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                T[]? data = JsonSerializer.Deserialize<T[]>(fs);
                Console.WriteLine("data deserialized");
                if (data != null)
                {
                    foreach (var employee in data)
                    {
                        yield return employee;
                    }
                }
            }
        }
        public void SaveData(IEnumerable<T> data, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, data, options);
            }
        }
    }
}