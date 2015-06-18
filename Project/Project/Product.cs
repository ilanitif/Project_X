namespace Project
{
    public class Product
    {
        public string Name { get; set; }
        public readonly int Id;
        public static int counter;
        public SubCategory SubCategory;



        public Product()
        {
            Id = counter++;
        }
    }
}