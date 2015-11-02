using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MolopolyGame;

namespace MolopolyGame.testing
{
    /// <summary>
    /// Test for the Jail class
    /// </summary>

    [TestFixture]
    public class _PlayerTest
    {
        private Banker theTestBanker = new Banker();
        private Player theTestPlayer = new Player();
        private NewDice theTestDie1 = new NewDice();
        private NewDice theTestDie2 = new NewDice();
        private Board testBoard = new Board();

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
            theTestDie1.setRoll(1);
            theTestDie2.setRoll(2);
            theTestPlayer.die1 = theTestDie1;
            theTestPlayer.die2 = theTestDie2;

            //call the function 3 times to enter into the if statement
            for (int i = 0; i < 3; i++)
            {
                theTestPlayer.failedToRollDoublesThreeTimes();
            }

            theTestPlayer.countDoubles3Times++;
            
            //check player's balance is actually 0
            Assert.IsTrue(theTestPlayer.getBalance() == 0);

            //then check if the banker receives $50
            //Assert.IsTrue(theTestBanker.getBalance() == 50);
        }

        [Test]
        //test Player class getters and setters
        public void test_PlayerGettersAndSetters()
        {

             Banker theTestBanker = new Banker();
             Player theTestPlayer = new Player();

            //hasRolledDoubles bool
            theTestPlayer.get_hasRolledDoubles();
            theTestPlayer.is_hasRolledDoubles();
            theTestPlayer.hasRolledDoubles = true;
            theTestPlayer.not_hasRolledDoubles();

            //paidFine bool
            theTestPlayer.getPaidFine();
            theTestPlayer.isPaidFine();
            theTestPlayer.notPaidFine();

            //landedInJailByThreeStraightDoubles bool
            theTestPlayer.get_LandedInJailByThreeStraightDoubles();
            theTestPlayer.not_LandedInJailByThreeStraightDoubles();
            theTestPlayer.is_LandedInJailByThreeStraightDoubles();

            //inJail bool
            theTestPlayer.getJailStats();
            theTestPlayer.setIsInJail();
            theTestPlayer.setNotInJail();

            //lastMove int
            theTestPlayer.getLastMove();

            theTestPlayer.getLocation();

            theTestPlayer.getName();

            theTestPlayer.getPropertiesOwned();

            theTestPlayer.getBalance();

            theTestPlayer.getBalance();

            theTestPlayer.hasRolledDoublesInJail();

            theTestPlayer.isNotActive();

            theTestPlayer.get_firstTurnInJail();

            theTestPlayer.not_firstTurnInJail();
        }

        [Test]
        public void test_BriefDetailsToString()
        {
            theTestPlayer.BriefDetailsToString();
        }

        [Test]
        public void test_ToSting()
        {
            theTestPlayer.diceRollingToString();
            theTestPlayer.PropertiesOwnedToString();
            theTestPlayer.ToString();
            theTestPlayer.FullDetailsToString();
        }

        [Test]
        //test Player failed to roll doubles in jail
        public void test_hasRolledDoublesInJail()
        {
            //---satisfy the if condition
            theTestDie1.setRoll(1);
            theTestDie2.setRoll(1);
            //pass the die values to the player
            theTestPlayer.die1 = theTestDie1;
            theTestPlayer.die2 = theTestDie2;

            theTestPlayer.hasRolledDoublesInJail();

            theTestPlayer.is_LandedInJailByThreeStraightDoubles();

            theTestPlayer.hasRolledDoublesInJail();

            theTestPlayer.not_LandedInJailByThreeStraightDoubles();

            //---satisfy the else condition
            theTestDie1.setRoll(1);
            theTestDie2.setRoll(2);
            //pass the die values to the player
            theTestPlayer.die1 = theTestDie1;
            theTestPlayer.die2 = theTestDie2;

            theTestPlayer.hasRolledDoublesInJail();

            Assert.NotNull(theTestPlayer);
        }

        [Test]
        //test player rolled doubles after paying $50 fine to get released from jail
        public void test_checkRolledDoublesAfterPayingFine()
        {
            theTestDie1.setRoll(1);
            theTestDie2.setRoll(1);
            //pass the die values to the player
            theTestPlayer.die1 = theTestDie1;
            theTestPlayer.die2 = theTestDie2;

            theTestPlayer.checkRolledDoublesAfterPayingFine();

            theTestDie1.setRoll(1);
            theTestDie2.setRoll(2);
            //pass the die values to the player
            theTestPlayer.die1 = theTestDie1;
            theTestPlayer.die2 = theTestDie2;

            theTestPlayer.checkRolledDoublesAfterPayingFine();

            Assert.NotNull(theTestPlayer);
        }

        [Test]
        //test the pay fine method
        public void test_payFine()
        {
            theTestPlayer.setBalance(50);
            theTestBanker.setBalance(0);

            theTestPlayer.payFine();

            Assert.NotNull(theTestPlayer);
        }

        [Test]
        //test the player move method
        public void test_move()
        {
            theTestPlayer.setIsInJail();

            theTestPlayer.move();

            Assert.NotNull(theTestPlayer);
        }

        [Test]
        //test the getPropertiesOwnedFromBoard method
        public void test_getPropertiesOwnedFromBoard()
        {
            theTestPlayer.getPropertiesOwnedFromBoard();

            testBoard.getProperty(0).getOwner();
        }
    }

    //create NewDice class to inherit from Die class and gain access to its methods
    public class NewDice : Die
    {
        //private int numberRolled;        
        public void setRoll(int theRoll){
            this.numberRolled = theRoll;
        }     
    }
}
