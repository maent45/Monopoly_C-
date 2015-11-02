using System;
using System.Collections;
using System.Text;

namespace MolopolyGame
{
    
    /// <summary>
    /// Class that represents a trader that can transfer money and own properties
    /// </summary>
    
    public class Trader //should be abstract but not to make testing easier
    {
        protected ArrayList propertiesOwned = new ArrayList();
        protected decimal dBalance; 
        protected string sName;
        protected bool hasReceivedPay = false;

        //null constructor implemented in inherited classes
        public Trader(){ }

        //constructor with name and balance
        public Trader(string sName, decimal dBalance)
        {
            this.sName = sName;
            this.dBalance = dBalance;
        }        

        public void receive(decimal dAmount)
        {
            //decimal previousBalance = this.getBalance();

            this.dBalance += dAmount;

            //if player's balance is greater than before then set hasReceivedpay to true
            //if (this.getBalance() > previousBalance)
            //{
            //    hasReceivedPay = true;
            //}
        }

        public void pay(decimal dAmount)
        {
            this.dBalance -= dAmount;
            checkBankrupt();
        }

        public virtual void checkBankrupt()
        {
            if (this.getBalance() <= 0)
                throw new ApplicationException(String.Format("{0} is Bankrupt", this.getName()));
        }
                
        

        public override string ToString()
        {
            return String.Format("Name: {0} \nBalance: {1}", this.sName, this.dBalance);
        }

        public String getName()
        {
            return this.sName;
        }

        public void setName(String sName)
        {
            this.sName = sName;
        }

        public void setBalance(decimal dBalance)
        {
            this.dBalance = dBalance;
        }

        public decimal getBalance()
        {
            return this.dBalance;
        }

        public void obtainProperty(ref Property property)
        {
            this.propertiesOwned.Add(property);
        }

        //get user input
        public int userInput()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\tPlease enter a number such as 1 or 2. Please try again.");
                return 0;
            }
        }
       
        public void tradeProperty(ref TradeableProperty property, ref Player purchaser, decimal amount)
        {
            //get property's original mortgage price
            decimal originalMortgagePrice = property.calculateMortgage(property);
            //get 10% of original mortgage price
            decimal originalMortgagePriceTenPercent = originalMortgagePrice * 10 / 100;
            decimal unMortgagePrice = originalMortgagePrice + originalMortgagePriceTenPercent;

            //purchaser.pay(amount);

            //check if purchased property is already mortgaged
            if (property.getMortgagedStatus() == true)
            {
                int userOption = 0;
                //if purchased property is mortgaged then player must unmortgage
                Console.WriteLine("\n\tThis property is currently mortgaged, you must either:\n\t1. Unmortgage it for the mortgage price plus 10%.\n\t2. Pay the bank 10% and keep it mortgaged.\n");

                //get user options input
                userOption = userInput();

                //grab user input value and run appropriate methods
                try
                {
                    switch (userOption)
                    {
                        case 1:
                            purchaser.pay(unMortgagePrice);
                            //---STILL NEED TO MAKE OTHER PLAYER RECEIVE PAYMENT
                            this.receive(unMortgagePrice);
                            property.setPropertyNotMortgaged();
                            property.setOwner(ref purchaser);
                            //property.unMortgage(property);
                            //Console.WriteLine("You've unmortgaged this property and now own it");
                            break;
                        case 2:
                            //pay 10%
                            purchaser.pay(originalMortgagePriceTenPercent);
                            //allocate da moneys to da banker
                            Banker.access().receive(originalMortgagePriceTenPercent);
                            //keep property as mortgaged
                            property.setPropertyIsMortgaged();

                            property.getMortgagedStatus();
                            //set owner
                            property.setOwner(ref purchaser);
                            break;
                    }
                }
                catch (ApplicationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                this.receive(amount);
                property.setOwner(ref purchaser);
            }            
        }

        internal ArrayList getPropertiesOwned()
        {
            return this.propertiesOwned;
        }


    }
}
