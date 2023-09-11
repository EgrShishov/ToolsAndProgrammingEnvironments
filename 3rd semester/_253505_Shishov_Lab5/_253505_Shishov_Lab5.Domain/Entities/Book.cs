using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Shishov_Lab5.Domain.Entities
{
    [Serializable]
    public class Book
    {
        public Book() { Name = "undefined"; Author = "undefined"; PagesAmount = 0; }
        public Book(string author, string name, int pages) { Name = name; Author = author; PagesAmount = pages; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PagesAmount { get; set; }

        public override string ToString()
        {
            return $"Book -> name - {Name}, author - {Author}, {PagesAmount} pages";
        }
    }
}
