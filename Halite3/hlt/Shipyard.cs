namespace Halite3.hlt
{
    public class Shipyard : Entity
    {
        public Shipyard(PlayerId owner, Position position) : base(owner, new EntityId(EntityId.NONE), position)
        {
        }

        public Command Spawn()
        {
            return Command.SpawnShip();
        }
    }
}