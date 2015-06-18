namespace Project
{
    public class Category
    {
        public string Name { get; set; }
        public readonly int Id;
        public static int counter;
     



        public Category()
        {
            Id = counter++;
        }
    }
}