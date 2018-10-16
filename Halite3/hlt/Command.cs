namespace Halite3.hlt
{
    public class Command
    {
        public readonly string command;

        public static Command SpawnShip()
        {
            return new Command("g");
        }

        public static Command TransformShipIntoDropoffSite(EntityId id)
        {
            return new Command("c " + id);
        }

        public static Command Move(EntityId id, Direction direction)
        {
            return new Command("m " + id + ' ' + (char)direction);
        }

        private Command(string command)
        {
            this.command = command;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            Command command1 = (Command)obj;

            return command.Equals(command1.command);
        }

        public override int GetHashCode()
        {
            return command.GetHashCode();
        }
    }
}