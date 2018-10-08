using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Halite3.hlt
{
    public class Game
    {
        private int turnNumber;

        public Game()
        {
            this.turnNumber = 0;

            //Grab constants JSON
            string rawConstants = Console.ReadLine();
            Constants.LoadConstants(rawConstants);
        }
    }
}