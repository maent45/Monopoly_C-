using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MolopolyGame;
using NUnit.Framework;
using System.IO;
using MolopolyGame.Testing;
using System.Collections;

namespace MolopolyGame.testing
{
    [TestFixture]
    //extend to Class Helper
    public class _MonopolyTest : ClassHelper
    {
        private Banker theTestBanker = new Banker();
        private Player theTestPlayer = new Player();
        private Monopoly testMonopoly = new Monopoly();
        //make instances to access class helper methods
        //REFERENCE -> Code below retrieved from Luke Hardiman
        private consoleReader testConsoleReader;
        private theConsoleIntercepter testTheConsoleIntercepter;

        //create constructor
        public _MonopolyTest()
        {
            //add board properties
            testMonopoly.setUpProperties();
            testTheConsoleIntercepter = new theConsoleIntercepter();
            testConsoleReader = new consoleReader();
            //set in and out
            Console.SetOut(testTheConsoleIntercepter);
            Console.SetIn(testConsoleReader);
        }

        /*--------------- TEST ALL JAIL MENU OPTIONS ---------------*/

        [Test]
        //test the player inside jail menu option 1
        public void test_displayInJailPlayerChoice_input1()
        {
            testConsoleReader.clear();
            //enter input
            testConsoleReader.useTheKey("1");
            testConsoleReader.useTheKey(" ");
            //now clear the console
            testTheConsoleIntercepter.ClearConsole();
            //prompt menu
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);
            //make ArrayList to get the output
            ArrayList T = testTheConsoleIntercepter.getOutPut();
            //assert that the input is actually 
            Assert.IsTrue((T[1].ToString() == "1. Finish Turn"));
            //now clear the console again
            testMonopoly.inputInteger();
            Assert.NotNull(testMonopoly);
        }

        [Test]
        //test the player inside jail menu option 2
        public void test_displayInJailPlayerChoice_input2()
        {
            testConsoleReader.clear();
            //enter input
            testConsoleReader.useTheKey("2");
            testConsoleReader.useTheKey(" ");
            //now clear the console
            testTheConsoleIntercepter.ClearConsole();
            //prompt menu
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);
            //make ArrayList to get the output
            ArrayList T = testTheConsoleIntercepter.getOutPut();
            //assert that the input is actually 
            Assert.IsTrue((T[2].ToString() == "2. Start New Game"));
            //now clear the console again
            testMonopoly.inputInteger();
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);
            Assert.NotNull(testMonopoly);
        }

        [Test]
        //test the player inside jail menu option 3
        public void test_displayInJailPlayerChoice_input3()
        {
            testConsoleReader.clear();
            //enter input
            testConsoleReader.useTheKey("3");
            testConsoleReader.useTheKey(" ");
            //now clear the console
            testTheConsoleIntercepter.ClearConsole();
            //prompt menu
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);

            //now clear the console again
            testMonopoly.inputInteger();
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);
            Assert.NotNull(testMonopoly);
        }

        [Test]
        //test the player inside jail menu option 4
        public void test_displayInJailPlayerChoice_input4()
        {
            testConsoleReader.clear();
            //enter input
            testConsoleReader.useTheKey("4");
            testConsoleReader.useTheKey(" ");
            //now clear the console
            testTheConsoleIntercepter.ClearConsole();
            //prompt menu
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);

            //now clear the console again
            testMonopoly.inputInteger();
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);
            Assert.NotNull(testMonopoly);
        }

        [Test]
        //test the player inside jail menu option 5
        public void test_displayInJailPlayerChoice_input5()
        {
            testConsoleReader.clear();
            //enter input
            testConsoleReader.useTheKey("5");
            testConsoleReader.useTheKey(" ");
            //now clear the console
            testTheConsoleIntercepter.ClearConsole();
            //prompt menu
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);

            //now clear the console again
            testMonopoly.inputInteger();
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);
            Assert.NotNull(testMonopoly);
        }

        [Test]
        //test the player inside jail menu option default
        public void test_displayInJailPlayerChoice_inputDefault()
        {
            testConsoleReader.clear();
            //enter input
            testConsoleReader.useTheKey("6");
            testConsoleReader.useTheKey(" ");
            //now clear the console
            testTheConsoleIntercepter.ClearConsole();
            //prompt menu
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);

            //now clear the console again
            testMonopoly.inputInteger();
            testMonopoly.displayInJailPlayerChoice(theTestPlayer);
            Assert.NotNull(testMonopoly);
        }

        /*--------------- END OF TEST ALL JAIL MENU OPTIONS ---------------*/

        [Test]
        //try and test the main menu choice
        public void test_displayMainChoiceMenu()
        {
            testMonopoly.displayMainChoiceMenu();
        }

        //[Test]
        public void test_displayPlayerChoiceMenu()
        {
            
            string[] lines = new[] { "1" };
            StringReader input = new StringReader(String.Join(Environment.NewLine, lines));
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetIn(input);

            //run the menu
            testMonopoly.displayPlayerChoiceMenu(theTestPlayer);
            //get input for the menu

            //Assert.NotNull(testMonopoly);
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
            Assert.IsTrue(Board.access().getProperty(0).getName() == "Go");
            Assert.IsTrue(Board.access().getProperty(0).getOwner().getName().ToString() == "Banker");
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
