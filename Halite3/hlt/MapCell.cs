namespace Halite3.hlt
{
    public class MapCell
    {
        public readonly Position position;
        public int halite;
        public Ship ship;
        public Entity structure;

        public MapCell(Position position, int halite)
        {
            this.position = position;
            this.halite = halite;
        }

        public bool IsEmpty()
        {
            return ship == null && structure == null;
        }

        public bool IsOccupied()
        {
            return ship != null;
        }

        public bool HasStructure()
        {
            return structure != null;
        }

        public void MarkUnsafe(Ship ship)
        {
            this.ship = ship;
        }
    }
}