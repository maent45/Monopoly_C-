using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //This is a die class that will generate random numbers between 1-6 which represents a dice roll.
    class Die
    {
        //create new instance of Randon
        private static Random numberGenerator = new Random();
        private int numberRolled;

        //roll method
        public int roll()
        {
            //min 1, 6
            numberRolled = numberGenerator.Next(1, 7);
            return numberRolled;
        }

        public int numberLastRolled()
        {
            return numberRolled;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
