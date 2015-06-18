using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class User
    {
        public string Name { get; set; }
        public readonly int Id;
        public static int counter;

      public  class Seller:User 
        {
            public Product Product;
        }


        public User()
        {
            Id = counter++;
        }
    }
}
