using System;
using System.Collections.Generic;

namespace Halite3.hlt
{
    public class GameMap
    {
        public readonly int width;
        public readonly int height;
        public readonly MapCell[][] cells;

        public GameMap(int width, int height)
        {
            this.width = width;
            this.height = height;

            cells = new MapCell[height][];
            for (int y = 0; y < height; ++y)
            {
                cells[y] = new MapCell[width];
            }
        }

        public MapCell At(Position position)
        {
            Position normalized = normalize(position);
            return cells[normalized.y][normalized.x];
        }

        public MapCell At(Entity entity)
        {
            return At(entity.position);
        }

        public int CalculateDistance(Position source, Position target)
        {
            Position normalizedSource = normalize(source);
            Position normalizedTarget = normalize(target);

            int dx = Math.Abs(normalizedSource.x - normalizedTarget.x);
            int dy = Math.Abs(normalizedSource.y - normalizedTarget.y);

            int toroidal_dx = Math.Min(dx, width - dx);
            int toroidal_dy = Math.Min(dy, height - dy);

            return toroidal_dx + toroidal_dy;
        }

        public Position normalize(Position position)
        {
            int x = ((position.x % width) + width) % width;
            int y = ((position.y % height) + height) % height;
            return new Position(x, y);
        }

        public List<Direction> GetUnsafeMoves(Position source, Position destination)
        {
            List<Direction> possibleMoves = new List<Direction>();

            Position normalizedSource = normalize(source);
            Position normalizedDestination = normalize(destination);

            int dx = Math.Abs(normalizedSource.x - normalizedDestination.x);
            int dy = Math.Abs(normalizedSource.y - normalizedDestination.y);
            int wrapped_dx = width - dx;
            int wrapped_dy = height - dy;

            if (normalizedSource.x < normalizedDestination.x)
            {
                possibleMoves.Add(dx > wrapped_dx ? Direction.WEST : Direction.EAST);
            }
            else if (normalizedSource.x > normalizedDestination.x)
            {
                possibleMoves.Add(dx < wrapped_dx ? Direction.WEST : Direction.EAST);
            }

            if (normalizedSource.y < normalizedDestination.y)
            {
                possibleMoves.Add(dy > wrapped_dy ? Direction.NORTH : Direction.SOUTH);
            }
            else if (normalizedSource.y > normalizedDestination.y)
            {
                possibleMoves.Add(dy < wrapped_dy ? Direction.NORTH : Direction.SOUTH);
            }

            return possibleMoves;
        }

        public Direction NaiveNavigate(Ship ship, Position destination)
        {
            // getUnsafeMoves normalizes for us
            foreach (Direction direction in GetUnsafeMoves(ship.position, destination))
            {
                Position targetPos = ship.position.DirectionalOffset(direction);
                if (!At(targetPos).IsOccupied())
                {
                    At(targetPos).MarkUnsafe(ship);
                    return direction;
                }
            }

            return Direction.STILL;
        }

        public void _update()
        {
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    cells[y][x].ship = null;
                }
            }

            int updateCount = Input.ReadInput().GetInt();

            for (int i = 0; i < updateCount; ++i)
            {
                Input input = Input.ReadInput();
                int x = input.GetInt();
                int y = input.GetInt();

                cells[y][x].halite = input.GetInt();
            }
        }

        public static GameMap _generate()
        {
            Input mapInput = Input.ReadInput();
            int width = mapInput.GetInt();
            int height = mapInput.GetInt();

            GameMap map = new GameMap(width, height);

            for (int y = 0; y < height; ++y)
            {
                Input rowInput = Input.ReadInput();

                for (int x = 0; x < width; ++x)
                {
                    int halite = rowInput.GetInt();
                    map.cells[y][x] = new MapCell(new Position(x, y), halite);
                }
            }

            return map;
        }
    }
}