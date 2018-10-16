using System;
using System.Collections.Generic;

namespace Halite3.hlt
{
    public enum Direction
    {
        NORTH = 'n',
        EAST = 'e',
        SOUTH = 's',
        WEST = 'w',
        STILL = 'o'
    }

    public static class DirectionExtensions
    {
        public static Direction InvertDirection(this Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH: return Direction.SOUTH;
                case Direction.EAST: return Direction.WEST;
                case Direction.SOUTH: return Direction.NORTH;
                case Direction.WEST: return Direction.EAST;
                case Direction.STILL: return Direction.STILL;
                default: throw new InvalidOperationException("Unknown direction " + direction);
            }
        }

        public static Direction[] ALL_CARDINALS = { Direction.NORTH, Direction.SOUTH, Direction.EAST, Direction.WEST };
    }
}