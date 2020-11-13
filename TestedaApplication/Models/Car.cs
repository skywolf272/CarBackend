namespace TestedaApplication.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string WholeDescription { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public bool IsFavourite { get; set; } = false;
        public int Avaliable { get; set; }
        public int CategoryID { get; set; }
    }
}
