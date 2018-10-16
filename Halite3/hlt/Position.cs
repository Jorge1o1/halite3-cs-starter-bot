using System;
using static Halite3.hlt.Direction;

namespace Halite3.hlt
{
    public class Position
    {
        public readonly int x;
        public readonly int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position DirectionalOffset(Direction d)
        {
            int dx;
            int dy;

            switch (d)
            {
                case NORTH:
                    dx = 0;
                    dy = -1;
                    break;

                case SOUTH:
                    dx = 0;
                    dy = 1;
                    break;

                case EAST:
                    dx = 1;
                    dy = 0;
                    break;

                case WEST:
                    dx = -1;
                    dy = 0;
                    break;

                case STILL:
                    dx = 0;
                    dy = 0;
                    break;

                default:
                    throw new InvalidOperationException("Unknown direction " + d);
            }

            return new Position(x + dx, y + dy);
        }
    }
}