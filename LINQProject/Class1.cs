using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProject
{
    internal class Class1
    {
        static void Main()
        {
            int[] arr = { 21, 56, 45, 23, 78, 34, 89, 66, 77, 89, 34, 56, 99, 88, 78 };

            var brr = from i in arr where i > 40 orderby i select i;

            foreach (var b in brr)
            {
                Console.WriteLine(b + " ");

                Console.ReadLine();
            }


        }
    }
}
