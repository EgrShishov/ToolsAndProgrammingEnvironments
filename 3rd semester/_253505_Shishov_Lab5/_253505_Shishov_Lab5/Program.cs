using _253505_Shishov_Lab5.Domain.Entities;
using SerializerLib;


Console.WriteLine("Hello, Walter!");
Serializer ser = new Serializer();

List<Library> libraries = new List<Library>();
libraries.Add(new Library("BSUIR6", new Book("glamazdin", "C# for beginners", 777)));
libraries.Add(new Library("BSUIR5", new Book("vladymtsev", "kak otchislit pol potoka", 666)));
libraries.Add(new Library("BSUIR4", new Book("pushkin","mama",123)));
libraries.Add(new Library("BSUIR3", new Book("lermontov", "papa", 13)));
libraries.Add(new Library("BSUIR2", new Book("dostoebskiy", "sestra", 433)));
libraries.Add(new Library("BSUIR1", new Book("pekarev", "brat", 666)));

Console.WriteLine("Исходная коллекция");
foreach(var item in libraries)
{
    Console.WriteLine(item);
}

ser.SerializeJSON(libraries,"libraryJSON.json");
var jsonCol = ser.DeSerializeJSON("libraryJSON.json");
ser.SerializeXML(libraries,"testXML.xml");
var xmlCol = ser.DeSerializeXML("testXML.xml");
ser.SerializeByLINQ(libraries,"testLINQ.xml");
var linqCol = ser.DeSerializeByLINQ("testLINQ.xml");

var json_equals = true;
var xml_equals = true;
var linq_equals = true;

var i = 0;
foreach (var book in jsonCol)
{
    if (book.Equals(libraries[i++]))
    {
        json_equals = false;
        break;
    }
}
i=0;
foreach (var book in xmlCol)
{
    if (book.Equals(libraries[i++]))
    {
        xml_equals = false;
        break;
    }
}
i=0;
foreach (var book in linqCol)
{
    if (book.Equals(libraries[i++]))
    {
        linq_equals = false;
        break;
    }
}
if (json_equals)
{
    Console.WriteLine("Исходная коллекция и коллекция, дессериализованная с .json файла одинаковы.");
}
else
{
    Console.WriteLine("Исходная коллекция и коллекция, дессериализованная с .json файла отличаются.");
}
if (xml_equals)
{
    Console.WriteLine("Исходная коллекция и коллекция, дессериализованная с .xml файла одинаковы.");
}
else
{
    Console.WriteLine("Исходная коллекция и коллекция, дессериализованная с .xml файла отличаются.");
}
if (linq_equals)
{
    Console.WriteLine("Исходная коллекция и коллекция, дессериализованная с linq-to-xml файла одинаковы.");
}
else
{
    Console.WriteLine("Исходная коллекция и коллекция, дессериализованная с linq-to-xml файла отличаются.");
}

Console.WriteLine("DesiarilizedJSON");
foreach(var book in jsonCol)
{
    Console.WriteLine(book);
}
Console.WriteLine("DesiarilizedXML");
foreach (var book in xmlCol)
{
    Console.WriteLine(book);
}
Console.WriteLine("DesiarilizedLINQ");
foreach (var book in linqCol)
{
    Console.WriteLine(book);
}

Console.WriteLine();
using (StreamReader reader = new StreamReader("libraryJSON.json"))
{
    var contains = reader.ReadToEnd();
    Console.WriteLine($"json file contains:\n{contains}");
}
Console.WriteLine();
using (StreamReader reader = new StreamReader("testXML.xml"))
{
    var contains = reader.ReadToEnd();
    Console.WriteLine($"xml file contains:\n{contains}");
}
Console.WriteLine();
using (StreamReader reader = new StreamReader("testLINQ.xml"))
{
    var contains = reader.ReadToEnd();
    Console.WriteLine($"linq-to-xml file contiuns:\n{contains}");
}