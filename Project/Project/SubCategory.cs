namespace Project
{
    public class SubCategory
    {
        public string Name { get; set; }
        public readonly int Id;
        public static int counter;
        public Category Category;



        public SubCategory()
        {
            Id = counter++;
        }
    }
}