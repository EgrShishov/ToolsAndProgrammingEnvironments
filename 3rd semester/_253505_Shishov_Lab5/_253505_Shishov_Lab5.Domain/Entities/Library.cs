using _253505_Shishov_Lab5.Domain.Entities;
namespace _253505_Shishov_Lab5.Domain.Entities
{
    [Serializable]
    public class Library : IEquatable<Library>
    {
        public string LibraryName { get; set; }
        public Book? Book { get; set; }

        public Library() { LibraryName  = "undefined"; }
        public Library(string name, Book book) { LibraryName = name; Book = book; }

        public override string ToString()
        {
            return $"Library -> {LibraryName}, {Book}";
        }
        public bool Equals(Library? other)
        {
            return other?.LibraryName == LibraryName && other.Book == Book;
        }
    }
}