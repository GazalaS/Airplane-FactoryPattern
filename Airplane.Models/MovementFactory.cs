namespace Airplane.Models
{
    public interface IMovementFactory
    {
        IMovement GetMovement(MovementType movementType);
    }
    public class MovementFactory: IMovementFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MovementFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IMovement GetMovement(MovementType movementType)
        {
            switch (movementType)
            {
                case MovementType.Forward:
                    return (IMovement)_serviceProvider.GetService(typeof(Forward))!;
                case MovementType.Up:
                    return (IMovement)_serviceProvider.GetService(typeof(Up))!;
                case MovementType.Down:
                    return (IMovement)_serviceProvider.GetService(typeof(Down))!;
                case MovementType.Dive:
                    return (IMovement)_serviceProvider.GetService(typeof(Dive))!;
                default:
                    throw new ArgumentOutOfRangeException(nameof(movementType), movementType, $"Movement of {movementType} is not supported.");
            }
        }
    }
}
