using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MolopolyGame
{
    //Jail class extends from the Property class
    public class Jail : Property
    {
        private bool isJail;
        public Jail() : this("Jail") { }

        //create Jail constructor
        public Jail(string sName, bool isJail = false)
        {
            this.sName = sName;
            this.isJail = isJail;
        }

        //create isJail boolean that will return isJail value
        public bool isJailProperty()
        {
            return this.isJail;
        }

        //create override method for original ToString method
        public override string ToString()
        {
            return base.ToString();
        }

        //overwrite original virtual method declared in Property class
        public override string landOn(ref Player player)
        {
            //if the following is a jail property and player has gone past then set player in jail
            if(this.isJail == true)
            {
                //enable setIsInJail to true
                player.setIsInJail();
                //don't let player pass GO and don't let collect $200
                player.setLocation(10, false);

                return base.landOn(ref player) + String.Format(player.getName() + " has gone to jail!");
            }
            else
            {
                if(player.getJailStats() == true)
                {
                    return base.landOn(ref player) + String.Format(player.getName() + " you're now in jail, you cannot pass Go or collect $200.00\nTo Get out of jail you must:\n \t-pay $50\n \t-use a 'Get out of Jail Card'\n \t-or attempt to roll doubles.\n");
                }
                else 
                {
                    return base.landOn(ref player) + String.Format(player.getName() + " is visiting jail!");
                }
                //when player is only visiting Jail
                //player.setNotInJail();
            }
        }
    }
}
