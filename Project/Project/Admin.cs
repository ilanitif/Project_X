using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Admin
    {
        public string Name { get; set; }
        public readonly int Id;
        public static int counter;
        
     

        public Admin()
        {
            Id = counter++;            
        }
    }
}
