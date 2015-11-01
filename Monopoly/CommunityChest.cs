using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MolopolyGame
{
    /// <summary>
    /// This class stores all of the community chest cards
    /// NOTE -> Most of the following code was obtained from Luke Hardiman and Michael Murray
    /// </summary>

    public class Community_Chest : Property
    {
        //create instances
        public Player theCurrentPlayer;
        public Banker theCurrentBank;
        public string sName;
        private List<ActionableCommunityChestCards> CommunityCardsActions;
        private Random random = new Random();
        private int cardPulled = 0;

        public Community_Chest() : this("Community Chest") { }

        //create the constructor
        public Community_Chest(string sName)
        {
            this.sName = sName;
            this.CommunityCardsActions = Shuffle(CardList());
        }

        //override the landOn method
        public override string landOn(ref Player player)
        {
            //if we have pulled the complete deck we need to reshuffle
            if (this.cardPulled >= this.CommunityCardsActions.Count) this.ShuffleCards();

            theCurrentBank = Banker.access();
            string drawedCord = draw_card(player);
            return base.landOn(ref player) + String.Format(drawedCord);

        }

        //method to shuffle the deck of cards
        public void ShuffleCards()
        {
            Console.Write(String.Format("Shuffling {0} cards  ", this.sName));
            List<ActionableCommunityChestCards> Community_Cards_Actions = Shuffle(CardList());
            Console.Write("Shuffled");
        }
        //REFERENCE for list of cards and actions was from ->  http://stackoverflow.com/questions/4910775/can-a-list-hold-multiple-void-methods

        //Deck of comunity chest cards
        public List<ActionableCommunityChestCards> CardList()
        {
            List<ActionableCommunityChestCards> Community_Cards_Actions = new List<ActionableCommunityChestCards>          
            {
                new ActionableCommunityChestCards
                    {
                          Name = "\n\tDoctor's fees – Pay $50 ",
                          Action = theDoctorsFee
                    },
                new ActionableCommunityChestCards
                {
                    Name = "\n\tAdvance To Go",
                    Action = advancePlayerToGo
                },
                
                new ActionableCommunityChestCards
                {
                    Name = "\n\tIt is your birthday Collect $10 from each player ",
                    Action = itsYourBirthdayPlayer
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tGrand Opera Night – collect $50 from every player for opening night seats ",
                    Action = nightForTheOpera
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tIncome Tax refund – collect $20",
                    Action = refundPlayersTax
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tPay Hospital Fees of $100 ",
                    Action = feesForTheHospital
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tPay School Fees of $50",
                    Action = feesForTheSchool
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tReceive $25 Consultancy Fee",
                    Action = feesForConsultancy
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tYou are assessed for street repairs – $40 per house, $115 per hotel ",
                    Action = street_repairs
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tYou have won second prize in a beauty contest– collect $10 ",
                    Action = contestForBeauty
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tYou inherit $100 ",
                    Action = playerInherit
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tFrom sale of stock you get $50 ",
                    Action = stockForSale
                },
                 new ActionableCommunityChestCards
                {
                    Name = "\n\tHoliday Fund matures - Receive $100",
                    Action = fundsForPlayersHoliday
                }                
            };
            return Community_Cards_Actions;
        }
        //confirmed that this action runs

        //method to draw a card from the deck
        public string draw_card(Player player)
        {
            ///Community_Cards_Actions
            theCurrentPlayer = player; //Current Player
            ActionableCommunityChestCards cardPull = CommunityCardsActions[this.cardPulled++];
            cardPull.Action.Invoke();
            return cardPull.Name.ToString();
        }
        
        //method to shuffle the cards
        private List<ActionableCommunityChestCards> Shuffle(List<ActionableCommunityChestCards> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                ActionableCommunityChestCards value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        /**
         * Card Methods below here 
         */
        public void theDoctorsFee()
        {
            theCurrentPlayer.pay(50);
            theCurrentBank.receive(50);
            Console.WriteLine("\n\tYour new balance is \n" + theCurrentPlayer.getBalance());
            Console.ReadLine();
        }

        public void advancePlayerToGo()
        {
            theCurrentPlayer.setLocation(0, false);
            //Console.WriteLine("Advance straight to GO");
        }

        public void itsYourBirthdayPlayer()
        {
            //collect $10 from all players on board
            foreach (Player otherPlayer in Board.access().getPlayers())
            {
                if (otherPlayer != theCurrentPlayer)
                {
                    otherPlayer.pay(10);
                    Console.WriteLine(String.Format("\n\t{0} paid you $10 ", otherPlayer.getName()));
                    theCurrentPlayer.receive(10);
                }
            }
        }

        public void nightForTheOpera()
        {
            foreach (Player otherPlayer in Board.access().getPlayers())
            {
                if (otherPlayer != theCurrentPlayer)
                {
                    otherPlayer.pay(50);
                    Console.WriteLine(String.Format("\n\t{0} paid you $50 ", otherPlayer.getName()));
                    theCurrentPlayer.receive(50);
                }
            }
            Console.WriteLine("\n\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }

        public void refundPlayersTax()
        {
            theCurrentPlayer.receive(20);
            theCurrentBank.pay(20);
            Console.WriteLine("\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }

        public void feesForTheHospital()
        {
            theCurrentPlayer.pay(100);
            theCurrentBank.receive(100);
            Console.WriteLine("\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }

        public void feesForTheSchool()
        {
            theCurrentPlayer.pay(50);
            theCurrentBank.receive(50);
            Console.WriteLine("\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }

        public void feesForConsultancy()
        {
            theCurrentPlayer.receive(25);
            theCurrentBank.pay(25);
            Console.WriteLine("\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }
        public void contestForBeauty()
        {
            theCurrentPlayer.receive(10);
            theCurrentBank.pay(10);
            Console.WriteLine("\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }
        public void playerInherit()
        {
            theCurrentPlayer.receive(100);
            theCurrentBank.pay(100);
            Console.WriteLine("\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }
        public void stockForSale()
        {
            theCurrentPlayer.receive(50);
            theCurrentBank.pay(50);
            Console.WriteLine("\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }

        public void fundsForPlayersHoliday()
        {
            theCurrentPlayer.receive(100);
            theCurrentBank.pay(100);
            Console.WriteLine("\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }
        public void street_repairs()
        {
            Console.WriteLine("\tYour new balance is \n\t" + theCurrentPlayer.getBalance());
        }
    }
}

public class ActionableCommunityChestCards
{
    public string Name { get; set; }
    public Action Action { get; set; }
}