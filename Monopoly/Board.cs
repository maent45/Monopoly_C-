using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // This is class for singleton Board that has properties and traders on it.
    public class Board
    {
        //provide a static instance of this class to create singleton
        static Board board;
        private ArrayList properties;
        private ArrayList players;
        int SQUARES = 40;

        //method to access Singleton
        public static Board access()
        {
            if (board == null)
                board = new Board();
            return board;
        }
        public Board()
        {
            properties = new ArrayList(this.getSquares());
            players = new ArrayList();
        }
        public int getSquares()
        {
            return this.SQUARES;
        }
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        //method to add a player --still need to create the Player class
        /*public void addPlayer(Player player)
        {
            players.Add(player);
        }*/

        //method to add property --still need to create the Property class
        /*public void addProperty(Property property)
        {
            this.properties.Add(property);
        }*/

        //method to return amount of players
        public int getPlayerCount()
        {
            return players.Count;
        }
    }
}
