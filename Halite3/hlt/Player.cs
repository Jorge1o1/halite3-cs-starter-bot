using System;
using System.Collections.Generic;

namespace Halite3.hlt
{
    public class Player
    {
        public readonly PlayerId id;
        public readonly Shipyard shipyard;
        public int halite;
        public readonly Dictionary<int, Ship> ships = new Dictionary<int, Ship>();
        public readonly Dictionary<int, Dropoff> dropoffs = new Dictionary<int, Dropoff>();

        private Player(PlayerId playerId, Shipyard shipyard, int halite = 0)
        {
            this.id = playerId;
            this.shipyard = shipyard;
            this.halite = halite;
        }

        public void _update(int numShips, int numDropoffs, int halite)
        {
            this.halite = halite;

            ships.Clear();
            for (int i = 0; i < numShips; ++i)
            {
                Ship ship = Ship._generate(id);
                ships[ship.id.id] = ship;
            }

            dropoffs.Clear();
            for (int i = 0; i < numDropoffs; ++i)
            {
                Dropoff dropoff = Dropoff._generate(id);
                dropoffs[dropoff.id.id] = dropoff;
            }
        }

        public static Player _generate()
        {
            Input input = Input.ReadInput();

            PlayerId playerId = new PlayerId(input.GetInt());
            int shipyard_x = input.GetInt();
            int shipyard_y = input.GetInt();

            return new Player(playerId, new Shipyard(playerId, new Position(shipyard_x, shipyard_y)));
        }
    }
}