using _253505_Shishov_Lab4.Entities;
using _253505_Shishov_Lab4.Services;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

Console.WriteLine("Hello, Walter!");

List<Goods> my_goods = new List<Goods>();
my_goods.Add(new Goods("soap", 123));
my_goods.Add(new Goods("rice", 111));
my_goods.Add(new Goods("snickers", 34));
my_goods.Add(new Goods("potato", 56));
my_goods.Add(new Goods("carrot", 12));
my_goods.Add(new Goods("diamond", 999));

FileService<Goods> service = new FileService<Goods>();
var extensions = new[] { ".txt", ".rtf", ".dat", ".inf" }; 

//заполнение текущей директории файлами
string curDirectory = Directory.GetCurrentDirectory();
string pathToFolder = $"{curDirectory}/Shishov_Lab4";
Console.WriteLine(curDirectory);
if(!Directory.Exists(pathToFolder))
{
Directory.CreateDirectory(pathToFolder);
}
Random rand = new Random();
if (Directory.GetFiles(pathToFolder).Length == 0) {
    for (int i = 0; i<10; i++)
    {
        int index = rand.Next(0, 4);
        string path = $"{pathToFolder}/{Path.GetRandomFileName()}{extensions[index]}";
        File.Create(path);
    }
}

//Выводим список файлов из директории
var DirectoryInfo = new DirectoryInfo(pathToFolder);
var files = DirectoryInfo.GetFiles();
foreach(var file in files)
{
    Console.WriteLine($"File : {file.Name}, has extension {file.Extension}");
}

var func = (string oldPath, string newPath) =>
{
    if (File.Exists(newPath))
    {
        File.Delete(newPath);
    }
    File.Move(oldPath, newPath);
};

//Сохраним коллекцию в файл, прочитаем в пустую и отсортируем с помощью LINQ запроса.
var txtFiles = DirectoryInfo.GetFiles("*.txt");
int randInd = rand.Next(0, txtFiles.Length - 1);
service.SaveData(my_goods, txtFiles[randInd].FullName);
var collection = service.ReadFile(txtFiles[randInd].FullName);
var sortedCollectionByName = collection.OrderBy(p => p, new MyCustomComparer<Goods>()).Select(p => p.Name);
var sortedCollectionByPrice = collection.OrderBy(p => p.Price).Select(p => p.Name +  ", " + p.Price);


Console.WriteLine("-------------------------\nBasic collection : ");
foreach (var item in my_goods)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("Sorted by name collection : ");
foreach (var item in sortedCollectionByName)
{
    Console.WriteLine(item);
}
Console.WriteLine("Sorted by price collection : ");
foreach (var item in sortedCollectionByPrice)
{
    Console.WriteLine(item);
}