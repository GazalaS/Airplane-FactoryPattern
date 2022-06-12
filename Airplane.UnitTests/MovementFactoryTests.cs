using Airplane.Extensions;
using Airplane.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Airplane.UnitTests
{
    public class MovementFactoryTests
    {
        [TestCase(MovementType.Forward)]
        [TestCase(MovementType.Up)]
        [TestCase(MovementType.Down)]
        [TestCase(MovementType.Dive)]        
        public void When_ValidMovement_Then_GetMovement(MovementType movementType)
        {
            //arrange
            var mockMovementFactory = new Mock<IMovementFactory>();

            //act
            mockMovementFactory.Object.GetMovement(movementType);

            //assert
            mockMovementFactory.Verify(m => m.GetMovement(movementType), Times.Once);                
        }

        [TestCase(MovementType.Unknown)]
        public void When_InvalidMovement_Then_ThrowError(MovementType movementType)
        {
            //arrange
            var serviceProvider = ServicesExtensions.BuildServiceProvider();
            var movementFactory = serviceProvider.GetService<IMovementFactory>();

            //act
            void Action() => movementFactory.GetMovement(movementType);

            //assert
            var exception = Assert.Throws<InvalidDataException>(Action);
            var message = "Movement of " +movementType+" is not supported.";
            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [TestCase(MovementType.Forward)]
        [TestCase(MovementType.Up)]
        [TestCase(MovementType.Down)]
        [TestCase(MovementType.Dive)]
        public void When_ValidMovement_Then_GetMovement_ValidObject(MovementType movementType)
        {
            var serviceProvider = ServicesExtensions.BuildServiceProvider();
            var movementFactory = serviceProvider.GetService<IMovementFactory>();

            var movement = movementFactory.GetMovement(movementType);

            switch(movementType)
            {
                case MovementType.Forward:
                    Assert.IsInstanceOf(typeof(Forward), movement);
                    return;
                case MovementType.Up:
                    Assert.IsInstanceOf(typeof(Up), movement);
                    return;
                case MovementType.Down:
                    Assert.IsInstanceOf(typeof(Down), movement);
                    return;
                case MovementType.Dive:
                    Assert.IsInstanceOf(typeof(Dive), movement);
                    return;
            }
        }
    }
}