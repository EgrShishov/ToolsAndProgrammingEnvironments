namespace ClassLibrary.Entities
{
    [Serializable]
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool isOverdue{ get; set; }

        public Goods() { Id = 0 ; Name = "undefined"; isOverdue = false; }
        public Goods(int id, string name, bool isOverdue)
        {
            this.Id = id; this.Name = name; this.isOverdue = isOverdue;
        }

        public override string ToString()
        {
            return $"Goods {Id} -> {Name}, isOverdue : {isOverdue}";
        }
    }
}