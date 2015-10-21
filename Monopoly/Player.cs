using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MolopolyGame
{

    /// <summary>
    /// Class for players playing monopoly
    /// </summary>

    //Player class extends Trader class
    public class Player : Trader
    {
        private int location;
        private int lastMove;
        private int countRoll;
        private int countDoubleRoll;

        private bool inJail;
        public bool firstTurnInJail = false;

        //each player has two dice
        Die die1 = new Die();
        Die die2 = new Die();
        bool isInactive = false;

        //create new instance of Banker class
        Banker banker = new Banker();

        //event for playerBankrupt
        public event EventHandler playerBankrupt;
        public event EventHandler playerPassGo;

        public Player()
        {
            this.sName = "Player";
            this.dBalance = InitialValuesAccessor.getPlayerStartingBalance();
            this.location = 0;
            this.inJail = false;
        }

        public Player(string sName)
        {
            this.sName = sName;
            this.dBalance = InitialValuesAccessor.getPlayerStartingBalance();
            this.location = 0;
            this.inJail = false;
        }

        public Player(string sName, decimal dBalance)
            : base(sName, dBalance)
        {
            this.location = 0;
        }

        /*----- MAIN METHOD TO CHECK FOR DOUBLE ROLLS -----*/
        public bool checkForDoubleRolls()
        {
            //if Dice 1 rolls same number as Dice 2 then increment count for doubles
            if (die1.ToString() == die2.ToString() || die2.ToString() == die1.ToString())
            {
                countDoubleRoll++;

                if(countDoubleRoll >= 3)
                {
                    this.firstTurnInJail = true;

                    Console.WriteLine("\tYou have rolled doubles 3 times, you've been sent to jail!");
                    //don't let player pass GO and don't let collect $200
                    this.setIsInJail();
                    this.setLocation(10, false);
                    
                    countDoubleRoll = 0;
                }
            }
            return true;
        }

        /*----- MAIN METHOD TO MAKE PLAYER MOVE ON BOARD -----*/
        public void move()
        {
            die1.roll();
            die2.roll();

            //if player has rolled doubles 3 times then send to jail
            checkForDoubleRolls();

            //check if player is in jail, if so restrict player from moving to other squares on next move
            if (this.getJailStats() == true)
            {
                Console.WriteLine("");
            }
            else
            {
                //move distance is total of both throws
                int iMoveDistance = die1.roll() + die2.roll();
                //increase location
                this.setLocation(this.getLocation() + iMoveDistance, false);
                this.lastMove = iMoveDistance;
            }
        }

        public int getLastMove()
        {
            return this.lastMove;
        }

        public string BriefDetailsToString()
        {
            if (getJailStats() == true)
            {
                Console.WriteLine("\tYou are in Jail! To get out you must:\n\t\t-Pay $50.00\n\t\t-Draw 'Get out of Jail Card'\n\t\t-Roll Doubles");
                return null;
            }
            else
            {
                return String.Format("You are on {0}.\tYou have ${1}.", Board.access().getProperty(this.getLocation()).getName(), this.getBalance());
            }
        }

        public override string ToString()
        {
            return this.getName();
        }

        public string FullDetailsToString()
        {
            return String.Format("\tPlayer:{0}.\n\tBalance: ${1}\n\tLocation: {2} (Square {3}) \n\tProperties Owned: {4}", this.getName(), this.getBalance(), Board.access().getProperty(this.getLocation()), this.getLocation(), this.PropertiesOwnedToString());
        }

        public string PropertiesOwnedToString()
        {
            string owned = "";
            //if none return none
            if (getPropertiesOwnedFromBoard().Count == 0)
                return "None";
            //for each property owned add to string owned
            for (int i = 0; i < getPropertiesOwnedFromBoard().Count; i++)
            {
                owned = getPropertiesOwnedFromBoard()[i].ToString() + "\n";
            }
            return owned;
        }

        public void setLocation(int location, bool playerCanPassGo)
        {
            //if set location is greater than number of squares then move back to beginning
            if (location >= Board.access().getSquares())
            {
                location = (location - Board.access().getSquares());
                //raise the pass go event if subscribers
                if (playerPassGo != null)
                    this.playerPassGo(this, new EventArgs());
                //add 200 for passing go
                this.receive(200);
            }

            this.location = location;
        }

        public int getLocation()
        {
            return this.location;
        }

        public string diceRollingToString()
        {
            return String.Format("Rolling Dice:\tDice 1: {0}\tDice 2: {1}", die1, die2);
        }

        public ArrayList getPropertiesOwnedFromBoard()
        {
            ArrayList propertiesOwned = new ArrayList();
            //go through all the properties
            for (int i = 0; i < Board.access().getProperties().Count; i++)
            {
                //owned by this player
                if (Board.access().getProperty(i).getOwner() == this)
                {
                    //add to arraylist
                    propertiesOwned.Add(Board.access().getProperty(i));
                }
            }
            return propertiesOwned;
        }

        public override void checkBankrupt()
        {
            if (this.getBalance() <= 0)
            {
                //raise the player bankrupt event if there are subscribers
                if (playerBankrupt != null)
                    this.playerBankrupt(this, new EventArgs());

                //return all the properties to the bank
                Banker b = Banker.access();
                foreach (Property p in this.getPropertiesOwnedFromBoard())
                {
                    p.setOwner(ref b);
                }
                //set isInactive to true
                this.isInactive = true;
            }
        }

        public bool isNotActive()
        {
            return this.isInactive;
        }

        /*----- PLAYER JAIL METHODS -----*/
        //return the jail status
        public bool getJailStats()
        {
            
            //will return value of inJail if true or false
            return this.inJail;
        }

        //send the player to jail
        public void setIsInJail()
        {
            firstTurnInJail = true;
            //set inJail var value to true to place player in jail
            this.inJail = true;
        }

        //player will not be in jail
        public void setNotInJail()
        {
            this.inJail = false;
        }

        //method to pay $50 to get out of jail
        public void payFine()
        {
            //pay $50 fine
            this.pay(50);
            //allocate that $50 to the banker
            banker.receive(50);
            //then release player from Jail
            this.setNotInJail();

            //this.inJail = true;
            Console.WriteLine("\t\tYou've paid $50 and have been released from Jail!\n\t\tPress ENTER to continue.");
            Console.ReadLine();
        }
    }
}
