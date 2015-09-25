using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointers
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5, j = 99, k = 109;
            //enable unsafe pointer
            unsafe
            {
                //declare int pointer
                int* myIntPointer;

                //direct the pointer to i address
                myIntPointer = &i;
                Console.WriteLine("memory address for var i is: " + (int)myIntPointer);
                Console.WriteLine("value for var i address is: " + *myIntPointer);

                Console.ReadLine();

                //direct the pointer to i address
                myIntPointer = &j;
                Console.WriteLine("memory address for var i is: " + (int)myIntPointer);
                Console.WriteLine("value for var i address is: " + *myIntPointer);

                Console.ReadLine();

                //direct the pointer to i address
                myIntPointer = &k;
                Console.WriteLine("memory address for var i is: " + (int)myIntPointer);
                Console.WriteLine("value for var i address is: " + *myIntPointer);

                Console.ReadLine();
            }
        }
    }
}
