using _253505_Shishov_Lab5.Domain.Entities;
using _253505_Shishov_Lab5.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SerializerLib
{
    public class Serializer : ISerializer
    {
        public IEnumerable<Library> DeSerializeByLINQ(string fileName)
        {
            XDocument xd = XDocument.Load(fileName);
            var libs = xd.Element("libraries")?.Elements("library").Select(
                p => new Library
                {
                    LibraryName = p.Attribute("libraryName")?.Value,
                    Book = new Book {
                        Author = p.Element("book")?.Attribute("author").Value,
                        Name = p.Element("book")?.Attribute("name").Value,
                        PagesAmount = int.Parse(p.Element("book")?.Attribute("pages_amount").Value)
                    }
                });

            if (libs != null)
            {
                foreach (var lib in libs)
                {
                    yield return lib;
                }
            }
        }

        public IEnumerable<Library> DeSerializeJSON(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open)) 
            {
                var Library = JsonSerializer.Deserialize<IEnumerable<Library>>(fs);
                if (Library != null)
                {
                    foreach (var item in Library)
                    {
                        yield return item;
                    }
                }
            }
        }

        public IEnumerable<Library> DeSerializeXML(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Library[]));
                Library[]? libs = serializer.Deserialize(fs) as Library[];
                if (libs != null)
                {
                    foreach(var item in libs)
                    {
                        yield return item;
                    }
                }
            }
        }

        public void SerializeByLINQ(IEnumerable<Library> xxx, string fileName)
        {
            XDocument xd = new XDocument();
            XElement libs = new XElement("libraries");
            foreach(var item in xxx)
            {
                XElement library = new XElement("library");
                library.Add(new XAttribute("libraryName", item.LibraryName));
                XElement book = new XElement("book");
                book.Add(new XAttribute("author", item.Book.Author));
                book.Add(new XAttribute("name", item.Book.Name));
                book.Add(new XAttribute("pages_amount", item.Book.PagesAmount));
                library.Add(book);
                libs.Add(library);
            }
            xd.Add(libs);
            xd.Save(fileName);
            Console.WriteLine("XML-document saves");
        }

        public void SerializeJSON(IEnumerable<Library> xxx, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            using FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            
            JsonSerializer.Serialize(fs, xxx, options);
            
        }

        public void SerializeXML(IEnumerable<Library> xxx, string fileName)
        {
            Library[] library = new Library[xxx.Count()];
            var i = 0;
            foreach (var item in xxx)
            {
                library[i++] = item;
            }
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Library[]));
                serializer.Serialize(fs, library);
            }
        }
    }
}