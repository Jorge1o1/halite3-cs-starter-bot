namespace Halite3.hlt
{
    public class Ship : Entity
    {
        public readonly int halite;

        public Ship(PlayerId owner, EntityId id, Position position, int halite) : base(owner, id, position)
        {
            this.halite = halite;
        }

        public bool IsFull()
        {
            return halite >= Constants.MAX_HALITE;
        }

        public Command MakeDropoff()
        {
            return Command.TransformShipIntoDropoffSite(id);
        }

        public Command Move(Direction direction)
        {
            return Command.Move(id, direction);
        }

        public Command StayStill()
        {
            return Command.Move(id, Direction.STILL);
        }

        public static Ship _generate(PlayerId playerId)
        {
            Input input = Input.ReadInput();

            EntityId shipId = new EntityId(input.GetInt());
            int x = input.GetInt();
            int y = input.GetInt();
            int halite = input.GetInt();

            return new Ship(playerId, shipId, new Position(x, y), halite);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            if (!base.Equals(obj)) return false;

            Ship ship = (Ship)obj;

            return halite == ship.halite;
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + halite;
            return result;
        }
    }
}