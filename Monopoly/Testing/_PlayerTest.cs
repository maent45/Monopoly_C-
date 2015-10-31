using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MolopolyGame.Testing
{
    /// <summary>
    /// Test for the Jail class
    /// </summary>

    [TestFixture]
    public class _PlayerTest
    {
        private Banker theTestBanker = new Banker();
        private Player theTestPlayer = new Player();
        private NewDice die1 = new NewDice();
        private NewDice die2 = new NewDice();

        [Test]
        public void test_threeStraightDoubles()
        {
            //create player
            Board.access().addPlayer(new Player("Player1"));
            //retrieve the player
            Board.access().getPlayer(0).setName("Player1");

            Board.access().getPlayer(0).countDoubleRoll = 3;

            //make player roll doubles
            Board.access().getPlayer(0).threeStraightDoubles();

            Assert.IsTrue(Board.access().getPlayer(0).getJailStats());
        }

        [Test]
        public void test_failedToRollDoublesThreeTimes()
        {
            theTestPlayer.setBalance(50);
            theTestBanker.setBalance(0);

            theTestPlayer.failedToRollDoublesThreeTimes();

            //
            Assert.NotNull(theTestPlayer);

            //set the dice
            die1.setRole(1);
            die2.setRole(2);
            theTestPlayer.die1 = die1;
            theTestPlayer.die2 = die2;

            //call the function 3 times to enter into the if statement
            for (int i = 0; i < 3; i++)
            {
                theTestPlayer.failedToRollDoublesThreeTimes();
            }

            //check player's balance is actually 0
            Assert.IsTrue(theTestPlayer.getBalance() == 0);

            //then check if the banker receives $50
            Assert.IsTrue(theTestBanker.getBalance() == 50);

            //theTestPlayer.die1;

            //set is in jail
            //Board.access().getPlayer(0).setIsInJail();
        }
    }


    public class NewDice : Die
    {

        //private int numberRolled;
        
        public void setRole(int theRoll){
            this.numberRolled = theRoll;
        }
 
        

    }
}
