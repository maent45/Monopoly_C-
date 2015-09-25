using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Multitask
{
    public class myUtil
    {
        public void addMethod(int num1, int num2)
        {
            Console.WriteLine("adding two values: " + (num1 + num2));
        }
        public void multiplyMethod(int num1, int num2)
        {
            Console.WriteLine("adding two values: " + (num1 * num2));
        }
        public void divideMethod(int num1, int num2)
        {
            Console.WriteLine("adding two values: " + (num1 / num2));
        }

    }
}
