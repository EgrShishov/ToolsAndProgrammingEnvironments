using _253505_Shishov_Lab6.Entities;
using System.Reflection;
using System.Xml;

Assembly asm = Assembly.LoadFrom("D:\\ISP\\3rd semester\\_253505_Shishov_Lab6\\_253505_Shishov_Lab6\\Debug\\net7.0\\FileServiceLibrary.dll");
Console.WriteLine("Types from .dll");
var types = asm.GetTypes();
Type? FileService = asm.GetType("_253505_Shishov_Lab6.Lib.Class.FileService`1").MakeGenericType(typeof(Employee));
var fs = Activator.CreateInstance(FileService);
MethodInfo? SaveData = FileService?.GetMethod("SaveData", new Type[] {typeof(IEnumerable<Employee>), typeof(string)});
MethodInfo? ReadFile = FileService?.GetMethod("ReadFile", new Type[] { typeof(string) });

foreach (var type in FileService.GetMethods())
{
    Console.WriteLine($"{type.Name}, {type.GetParameters}, {type.ReturnType}");
}

Console.WriteLine("Hello, Walter!");
var col = new List<Employee>();
col.Add(new Employee("Egor", 19, false));
col.Add(new Employee("Stas", 19, false));
col.Add(new Employee("Anton", 19, true));
col.Add(new Employee("Paul", 18, true));
col.Add(new Employee("Rostislav", 20, false));
col.Add(new Employee("Rayan Gosling", 43, true));

SaveData?.Invoke(fs, new object[]{ col, "test.json" }); 
var jsonCol = ReadFile?.Invoke(fs, new object[] { "test.json" }) as IEnumerable<Employee>;
foreach(var item in jsonCol)
{
    Console.WriteLine($"{item}");
}