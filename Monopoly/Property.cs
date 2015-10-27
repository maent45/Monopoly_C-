using System;
using System.Collections.Generic;
using System.Text;

namespace MolopolyGame
{
     /// <summary>
    /// Class that represents a generic property types
    /// </summary>
    /// 
    public class Property
    {
        protected string sName;
        protected Trader owner;
        protected bool bMortgaged;
        protected bool bUnMortgaged;
        protected decimal dPrice;
        //protected decimal mortgageRate;
        public Property(): this("Property"){}

        public Property(string sName)
        {
            this.sName = sName;
            this.owner = Banker.access();
        }

        public Property(string sName, ref Trader owner)
        {
            this.sName = sName;
            this.owner = owner;
        }
        public Trader getOwner()
        {
            return this.owner;
        }

        public void setOwner(ref Banker newOwner)
        {
            this.owner = newOwner;
        }

        public void setOwner(ref Player newOwner)
        {
            this.owner = newOwner;
        }

        public string getName()
        {
            return this.sName;
        }

        //overrideable method
        public virtual string landOn(ref Player player)
        {
            return String.Format("{0} landed on {1}. ", player.getName(), this.getName());
        }

        public override string ToString()
        {
            return String.Format("{0}:\tOwned by: {1}", this.getName(), this.getOwner().getName());
        }

        public virtual bool availableForPurchase()
        {
            return false;//generic properties are not available for purchase
        }

        /*------ METHODS TO MORTGAGE AND UNMORTGAGE PROPERTIES ------*/
        //REFERENCE -> snippets of the following methods were obtained from Luke Hardiman
        //is the property mortgage
        public virtual bool isMortgaged()
        {
            return this.bMortgaged;
        }

        //calculate the mortage value
        public virtual decimal calculateMortgage()
        {
            return this.dPrice * 80 / 100;
        }

        //logic for mortgaging propoety, add checks then proceed with mortgage
        public virtual void mortgageProperty()
        {
            this.bMortgaged = true;
        }

        /*----- METHOD TO UNMORTGAGE -----*/
        //calculate 10% of property price as the unmortgaging rate
        public virtual decimal calculateUnMortgage()
        {
            return this.dPrice * 10 / 100 + calculateMortgage();
        }

        //pay off the property mortgage
        public virtual void unMortgage()
        {
            //check if player has enough money in balance to pay off mortgage
            if (this.getOwner().getBalance() <= (this.calculateUnMortgage()))
            {
                Console.WriteLine("Sorry, you don't have enough moneys to pay off da mortgage!");
            }
            else
            {
                //if player can afford, then call payOffMortgage()
                payOffMortgage();
            }
        }

        //method to pay unMortgage of property
        private void payOffMortgage()
        {
            //get owner of this property
            this.getOwner().pay(calculateUnMortgage());
            //bank then receives payment
            Banker.access().receive(calculateUnMortgage());
            //then set isMortgaged to false
            this.bMortgaged = false;
        }
    }

   
}
