namespace Airplane.Models
{
    public interface IMovement
    {
        Position Move(Position position, int steps);
    }

    public class Forward : IMovement
    {
        public Position Move(Position position, int steps)
        {
            if (position.Horizontal != 0)
            {
                position.Vertical += (steps * position.Direction);
            }
            position.Horizontal += steps;
            return position;
        }
    }

    public class Up : IMovement
    {
        public Position Move(Position position, int steps)
        {
            position.Direction += steps;
            return position;
        }
    }

    public class Down : IMovement
    {
        public Position Move(Position position, int steps)
        {
            position.Direction -= steps;
            return position;
        }
    }
    public class Dive : IMovement
    {
        public Position Move(Position position, int steps)
        {
            position.Vertical -= steps;
            return position;
        }
    }
}