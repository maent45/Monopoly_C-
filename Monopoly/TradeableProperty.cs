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
        //REFERENCE -> snippets of the following methods were obtained from Luke Hardiman
        //is the property mortgaged?
        public virtual bool getMortgagedStatus()
        {
            return this.bMortgaged;
        }

        //calculate the mortage value
        public virtual decimal calculateMortgage(Property property)
        {
            decimal dMortgagePrice = 0;
            //Get types of properties
            //REFERENCE -> getting property type code retrieved from https://msdn.microsoft.com/en-us/library/58918ffs.aspx
            System.Type residential = typeof(Residential);
            System.Type utility = typeof(Utility);
            System.Type transport = typeof(Transport);

            if (property.GetType() == residential)
            {
                //cast the property as Residential
                Residential residentialProperty = (Residential)property;
                dMortgagePrice = residentialProperty.getPrice();
            }
            else if (property.GetType() == utility)
            {
                //cast the property as Utility
                Utility utilityProperty = (Utility)property;
                dMortgagePrice = utilityProperty.getPrice();
            }
            else if (property.GetType() == transport)
            {
                //cast the property as Transport
                Transport transportProperty = (Transport)property;
                dMortgagePrice = transportProperty.getPrice();
            }

            return dMortgagePrice * 80 / 100;

        }

        //logic for mortgaging propoety, add checks then proceed with mortgage
        public virtual void setPropertyIsMortgaged()
        {
            this.bMortgaged = true;
        }

        public void setPropertyNotMortgaged()
        {
            this.bMortgaged = false;
        }

        /*----- METHODS TO UNMORTGAGE -----*/
        //calculate 10% of property price as the unmortgaging rate
        public virtual decimal calculateUnMortgage(Property property)
        {
            return this.dPrice * 10 / 100 + calculateMortgage(property);
        }

        //pay off the property mortgage
        public virtual void unMortgage(Property property)
        {
            //check if player has enough money in balance to pay off mortgage
            if (this.getOwner().getBalance() <= (this.calculateUnMortgage(property)))
            {
                Console.WriteLine("Sorry, you don't have enough moneys to pay off da mortgage!");
            }
            else
            {
                //if player can afford, then call payOffMortgage()
                payOffMortgage(property);
            }
        }

        //method to pay unMortgage of property
        private void payOffMortgage(Property property)
        {
            //get owner of this property
            this.getOwner().pay(calculateUnMortgage(property));
            //bank then receives payment
            Banker.access().receive(calculateUnMortgage(property));
            //then set isMortgaged to false
            this.bMortgaged = false;
        }

        /*=======================================================================*/

        /*------ METHODS TO MORTGAGE AND UNMORTGAGE PROPERTIES ------*/
        //is the property mortgage
        //public virtual bool isMortgaged()
        //{
        //    return this.bMortgaged;
        //}

        //calculate the mortage value
        /*public virtual decimal calculateMortgage()
        {
            return this.dPrice * 80 / 100;
        }

        //logic for mortgaging propoety, add checks then proceed with mortgage
        public virtual void mortgageProperty()
        {
            this.bMortgaged = true;
        }*/

        /*----- METHODS TO UNMORTGAGE -----*/
        //calculate 10% of property price as the unmortgaging rate
        /*public virtual decimal calculateUnMortgage()
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
        }*/
    }
}
