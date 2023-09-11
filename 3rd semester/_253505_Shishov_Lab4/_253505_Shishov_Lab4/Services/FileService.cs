using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253505_Shishov_Lab4.Entities;
using _253505_Shishov_Lab4.Interfaces;

namespace _253505_Shishov_Lab4.Services
{
    internal class FileService<T> : IFileService<T> where T : Goods
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    int price = reader.ReadInt32();
                    bool sold = reader.ReadBoolean();
                    var Good = new Goods(name, price, sold);
                    yield return Good as T;
                }
                if (reader.PeekChar() > -1)
                {
                    yield break;
                }
            }
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"#FileServiceInfo -> file {fileName} was deleted");
                Console.ForegroundColor = ConsoleColor.White;
            }
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(fileName)))
                {
                    foreach (var item in data)
                    {
                        writer.Write(item.Name);
                        writer.Write(item.Price);
                        writer.Write(item.Sold);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I catched BinaryWriter object exception {ex.Message}");
            }
        }

        public void RenameFile(string oldFileName, string newFileName)
        {
            if (!File.Exists(newFileName) && File.Exists(oldFileName))
            {
                File.Move(oldFileName, newFileName);
                Console.WriteLine("File renamed");
                File.Delete(oldFileName);
            } else
            {
                Console.WriteLine($"FileService -> {newFileName} is already exists");
            }
        }
    }
}
