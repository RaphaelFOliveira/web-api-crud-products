namespace ProductsApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
    }
}
