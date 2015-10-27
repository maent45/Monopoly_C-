using System;
using System.Collections.Generic;
using System.Text;

namespace MolopolyGame
{
    public class TradeableProperty : Property //should be abstract but not to make testing easier
    {
        protected decimal dPrice;
        protected decimal dMortgageValue;
        protected decimal dRent;
        protected bool bMortgaged;

        public TradeableProperty()
        {
            this.dPrice = 200;
            this.dMortgageValue = 100;
            this.dRent = 50;
            this.bMortgaged = false;
        }

        public decimal getPrice()
        {
            return dPrice;
        }

        public virtual decimal getRent()
        {
            return this.dRent;
        }

        public virtual void payRent(ref Player player)
        {
            player.pay(this.getRent());
            this.getOwner().receive(this.getRent());
        }

        public void purchase(ref Player buyer)
        {
            //check that it is owned by bank
            if (this.availableForPurchase())
            {
                //pay price 
                buyer.pay(this.getPrice());
                //set owner to buyer
                this.setOwner(ref buyer);
            }
            else
            {
                throw new ApplicationException("The property is not available from purchase from the Bank.");
            }
        }

        public override bool availableForPurchase()
        {
            //if owned by bank then available
            if (this.owner == Banker.access())
                return true;
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override string landOn(ref Player player)
        {
            //Pay rent if needed
            if ((this.getOwner() != Banker.access()) && (this.getOwner() != player))
            {
                //pay rent
                this.payRent(ref player);
                return base.landOn(ref player) + string.Format("Rent has been paid for {0} of ${1} to {2}.", this.getName(), this.getRent(), this.getOwner().getName());
            }
            else
                return base.landOn(ref player);
        }

        /*------ METHODS TO MORTGAGE AND UNMORTGAGE PROPERTIES ------*/
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
        public virtual void mortgagePropery()
        {
            this.bMortgaged = true;
        }
    }
}