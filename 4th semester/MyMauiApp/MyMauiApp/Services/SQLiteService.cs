using MyMauiApp.Entities;
using SQLite;

namespace MyMauiApp.Services
{
    public class SQLiteService : IDbService
    {
        private SQLiteConnection database = null;
        public IEnumerable<Author> GetAllAuthors()
        {
            Init();

            return database.Table<Author>().ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            Init();

            return from book in database.Table<Book>() where book.AuthorId == authorId select book;
        }

        public void Init()
        {
            if (database != null) return;
            database = new SQLiteConnection("D:\\ISP\\4th semester\\MyMauiApp\\DataBase.db");

            //temporary
            database.DropTable<Book>();
            database.DropTable<Author>();

            database.CreateTable<Book>();
            database.CreateTable<Author>();

            List<Book> books = new List<Book>
            {
                new Book{AuthorId = 1, Title = "Murder on the Orient Express", Year = 1956, PagesAmount = 243, Description = "A train stopped at midnight in the snow. A dead body found in a compartment. Twelve stab wounds leave no doubt it was murder. And Hercule Poirot, tasked with solving the crime, is certain the culprit is a passenger on the Orient Express."},
                new Book{AuthorId = 2, Title = "50 shades of grey", Year = 2004, PagesAmount = 200, Description = "For all the trappings of success—his multinational businesses, his vast wealth, his loving family—Grey is a man tormented by demons and consumed by the need to control. "},
                new Book{AuthorId = 3, Title = "It", Year = 2014, PagesAmount = 456, Description = "The story follows the experiences of seven children as they are terrorized by an evil entity that exploits the fears of its victims to disguise itself while hunting its prey."},
                new Book{AuthorId = 1, Title = "Born on the West Express", Year = 1956, PagesAmount = 243, Description = "A train stopped at midnight in the snow. A dead body found in a compartment. Twelve stab wounds leave no doubt it was murder. And Hercule Poirot, tasked with solving the crime, is certain the culprit is a passenger on the Orient Express."},
                new Book{AuthorId = 2, Title = "Introduction into coocking", Year = 2004, PagesAmount = 200, Description = "For all the trappings of success—his multinational businesses, his vast wealth, his loving family—Grey is a man tormented by demons and consumed by the need to control. "},
                new Book{AuthorId = 3, Title = "Animal's graveyard", Year = 2014, PagesAmount = 456, Description = "The story follows the experiences of seven children as they are terrorized by an evil entity that exploits the fears of its victims to disguise itself while hunting its prey."},
                new Book{AuthorId = 1, Title = "The Big Four", Year = 1927, PagesAmount = 202, Description = "Framed in the doorway of Poirot’s bedroom stood an uninvited guest, coated from head to foot in dust. The man’s gaunt face stared for a moment, then he swayed and fell. Who was he? Was he suffering from shock or just exhaustion? "},
                new Book{AuthorId = 1, Title = "The ABC murders", Year = 1936, PagesAmount = 199, Description = "There’s a serial killer on the loose, working his way through the alphabet - and the whole country is in a state of panic. A is for Mrs Ascher in Andover, B is for Betty Barnard in Bexhill, C is for Sir Carmichael Clarke in Churston. "},
                new Book{AuthorId = 1, Title = "Death on the Nile", Year = 1937, PagesAmount = 341, Description = "The tranquillity of a cruise along the Nile is shattered by the discovery that Linnet Ridgeway has been shot through the head. She was young, stylish and beautiful, a girl who had everything – until she lost her life.\r\nThe tranquillity of a cruise along the Nile is shattered by the discovery that Linnet Ridgeway has been shot through the head. She was young, stylish and beautiful, a girl who had everything – until she lost her life."},
                new Book{AuthorId = 3, Title = "Billy Summers", Year = 2021, PagesAmount = 499, Description = "Billy Summers is a man in a room with a gun. He’s a killer for hire and the best in the business. But he’ll do the job only if the target is a truly bad guy. And now Billy wants out. But first there is one last hit. "},
                new Book{AuthorId = 3, Title = "Revival", Year = 2014, PagesAmount = 341, Description = "A novel about addiction, religion, music and what might exist on the other side of life."}
        };

            List<Author> authors = new List<Author>
            {
                new Author{Name = "Aghata Kristy", Age = 40},
                new Author{Name = "E.L. James", Age = 36},
                new Author{Name = "Steven King", Age = 56}
            };

            database.InsertAll(books);
            database.InsertAll(authors);
        }
    }
}
