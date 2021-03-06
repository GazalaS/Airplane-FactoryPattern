using Airplane.Models;

namespace Airplane.Services
{
    public interface IAirplaneNavigationService
    {
        void Navigate(string fileName){ }
    }
    public class AirplaneNavigationService : IAirplaneNavigationService
    {
        private readonly IMovementFactory _movementFactory;
        private IReadInputService _readInputService { get; }
        private Position _position { get; }
        private IWriteOutputService _writeOutputService { get; }

        public AirplaneNavigationService(IMovementFactory movementFactory, IReadInputService readInputService, IWriteOutputService writeOutputService)
        {
            _movementFactory = movementFactory;
            _readInputService = readInputService;
            _position = new Position();
            _writeOutputService = writeOutputService;
        }

        public void Navigate(string fileName)
        {
            int totalPosition = 0;
            var commands = _readInputService.ReadCommandsFromFile(fileName);

            _writeOutputService.WriteLine("Calculating Navigation Position...");

            if (commands != null)
            {
                totalPosition = CalculateAirplaneNavigation(commands);
            }

            _writeOutputService.WriteLine(totalPosition.ToString());
        }
        private int CalculateAirplaneNavigation(List<KeyValuePair<string, int>> commands)
        {
            IMovement movement;
            foreach (KeyValuePair<string, int> command in commands)
            {
                movement = ParseMovementType(command.Key);
                int steps = command.Value;
                movement.Move(_position, steps);
            }
            return _position.Horizontal * _position.Vertical;
        }

        private IMovement ParseMovementType(string movement)
        {
            switch (movement)
            {
                case Constants.FORWARD:
                    return _movementFactory.GetMovement(MovementType.Forward);
                case Constants.UP:
                    return _movementFactory.GetMovement(MovementType.Up);
                case Constants.DOWN:
                    return _movementFactory.GetMovement(MovementType.Down);
                case Constants.DIVE:
                    return _movementFactory.GetMovement(MovementType.Dive);
                default:
                    throw new InvalidDataException("Invalid input.");
            }
        }
    }
}

