using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Multitask
{
    class Program
    {
        public delegate int Calculate(int value1, int value2);
        static void Main(string[] args)
        {
            myUtil myUtilObject = new myUtil();

            Calculate calculateFunction = new Calculate(myUtilObject.addMethod);

            calculateFunction = calculateFunction + new Calculate(myUtilObject.divideMethod);
            calculateFunction = calculateFunction + new Calculate(myUtilObject.multiplyMethod);

        }
    }
}
