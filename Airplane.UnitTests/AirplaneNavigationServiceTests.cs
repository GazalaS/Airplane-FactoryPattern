using Airplane.Extensions;
using Airplane.Models;
using Airplane.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Airplane.UnitTests
{
    public class AirplaneNavigationServiceTests
    {
        [TestCase(@"C:\Input\commands3.txt")]
        [TestCase(@"C:\Input\commands4.txt")]
        public void When_ValidInput_Then_Navigate(string fileName)
        {
            //arrange
            var mockMovementFactory = new Mock<IMovementFactory>().Object;
            var mockReadInputService = new Mock<IReadInputService>().Object;
            var mockPosition = new Mock<Position>().Object;
            var mockWriteOutputService = new Mock<IWriteOutputService>().Object;      

            var airplaneServiceNavigation = new AirplaneNavigationService(mockMovementFactory, mockReadInputService, mockWriteOutputService);

            //act
            void Action() => airplaneServiceNavigation.Navigate(fileName);

            //assert
            Assert.DoesNotThrow(Action);
        }

        [TestCase(@"C:\Input\commandsUnknown.txt")]
        public void When_InvalidInput_Then_ThrowException(string fileName)
        {
            //arrange
            var serviceProvider = ServicesExtensions.BuildServiceProvider();
            var movementFactory = serviceProvider.GetService<IMovementFactory>();
            var readInputService = serviceProvider.GetService<IReadInputService>();
            var writeOutputService = serviceProvider.GetService<IWriteOutputService>();

            var airplaneServiceNavigation = new AirplaneNavigationService(movementFactory, readInputService, writeOutputService);

            //act
            void Action() => airplaneServiceNavigation.Navigate(fileName);

            //assert
            var exception = Assert.Throws<InvalidDataException>(Action);
            Assert.That(exception.Message, Is.EqualTo("Invalid input."));
        }
    }
}
