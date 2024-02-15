using SQLite;

namespace MyMauiApp.Entities
{
    [Table("Authors")]
    public class Author
    {
        [PrimaryKey, AutoIncrement, Indexed] 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
