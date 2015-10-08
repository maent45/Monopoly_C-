using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //this class provides Interface for games
    interface GameInterface
    {
        void initializeGame();
        void makePlay(int player);
        bool endOfGame();
        void printWinner();
        void playOneGame();
    }
}
