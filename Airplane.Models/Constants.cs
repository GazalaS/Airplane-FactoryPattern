namespace Airplane.Models
{
    public static class Constants
    {
        public const string FORWARD = "forward"; 
        public const string UP = "up";
        public const string DOWN = "down";
        public const string DIVE = "dive";
    }
    public enum MovementType
    {
        Forward,
        Up,
        Down,
        Dive,
        Unknown
    }
}