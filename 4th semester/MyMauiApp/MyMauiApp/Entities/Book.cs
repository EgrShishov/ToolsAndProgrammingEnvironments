using SQLite;

namespace MyMauiApp.Entities
{
    [Table("Books")]
    public class Book
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PagesAmount { get; set; }
        public int Year { get; set; }
        [Indexed]
        public int AuthorId { get; set; }
    }
}
