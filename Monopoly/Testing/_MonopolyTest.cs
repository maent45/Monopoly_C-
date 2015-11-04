using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MolopolyGame;
using NUnit.Framework;

namespace MolopolyGame.testing
{
    [TestFixture]    
    public class _MonopolyTest
    {
        private Banker theTestBanker = new Banker();
        private Player theTestPlayer = new Player();
        private Monopoly testMonopoly = new Monopoly();

        /*[Test] --NEED TO DO PROPER TESTING FOR MONOPOLY CLASS
        //test the player inside jail menu
        public void test_displayInJailPlayerChoice()
        {
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);
            Assert.NotNull(testMonopoly);
        }*/ 

        [Test]
        //try and test the main menu choice
        public void test_displayMainChoiceMenu()
        {
            testMonopoly.displayMainChoiceMenu();
            Assert.NotNull(testMonopoly);
        }

        [Test]
        public void test_displayPlayerChoiceMenu()
        {         
            testMonopoly.displayPlayerChoiceMenu(theTestPlayer);
            Assert.NotNull(testMonopoly);
        }

        [Test]
        //try and test purchaseProperty
        public void test_purchaseProperty()
        {
            testMonopoly.purchaseProperty(theTestPlayer);
            theTestPlayer.setIsInJail();
            Assert.NotNull(theTestPlayer);
        }

        [Test]
        //try and test the initialize game method
        public void test_initializeGame()
        {
            testMonopoly.initializeGame();
            Assert.NotNull(testMonopoly);
        }

        [Test]
        //test for the setup of game properties
        public void test_setUpProperties()
        {
            testMonopoly.setUpProperties();
            Assert.NotNull(testMonopoly);
        }

        //[Test]
        ////test for the setting up of players
        //public void test_setUpPlayers()
        //{
        //    testMonopoly.setUpPlayers();

        //    testMonopoly.inputInteger()

        //    Assert.NotNull(testMonopoly);
        //}

    }
}
