using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           StringBuilder sr = new StringBuilder("ilanit");
            Console.WriteLine(sr.ToString(), sr.Length,sr.MaxCapacity.ToString());
            sr.Insert(3, "rooomy");
            Console.WriteLine(sr);
            sr.Replace('r', '8');
            Console.WriteLine(sr);
            sr.Remove(3,5);
            Console.WriteLine(sr);
            sr.Append(true);
            Console.WriteLine(sr);
        }
    }
}