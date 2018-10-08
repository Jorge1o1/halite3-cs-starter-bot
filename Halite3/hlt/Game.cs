using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Halite3.hlt
{
    /// <summary>
    /// The game object holds all metadata pertinent to the game and all its contents
    /// </summary>
    public class Game
    {
        private int turnNumber;
        private int myId;

        /// <summary>
        /// Initiates a game object collecting all start-state instances for the contained items for pre-game.
        /// Also sets up basic logging.
        /// </summary>
        public Game()
        {
            this.turnNumber = 0;

            //Grab constants JSON
            Constants.LoadConstants(Console.ReadLine());

            string[] numPlayersAndIdStrArr = Console.ReadLine().Split();
            int numPlayers = int.Parse(numPlayersAndIdStrArr[0]);
            this.myId = int.Parse(numPlayersAndIdStrArr[1]);

            Log.Initialize(new StreamWriter(String.Format("bot-{0}.log", myId)));
        }
    }
}