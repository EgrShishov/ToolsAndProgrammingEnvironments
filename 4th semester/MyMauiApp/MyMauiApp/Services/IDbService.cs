using MyMauiApp.Entities;

namespace MyMauiApp.Services
{
    public interface IDbService
    {
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Book> GetBooksByAuthor(int Id);
        void Init();
    }
}