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
        protected decimal mortgageRate;
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

        //method to calculate the mortgage price
        //public decimal calculateMortgage()
        //{
        //    Monopoly monopoly = new Monopoly();

        //    mortgageRate = monopoly.prop
        //    return;
        //}
    }

   
}
