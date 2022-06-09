using Airplane.Models;
using Airplane.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Airplane.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceProvider BuildServiceProvider()
        {
            //setup our DI

            var serviceProvider = new ServiceCollection()
                .AddScoped<IReadInputService, ReadInputService>()
                .AddScoped<IWriteOutputService, WriteOutputService>()
                .AddTransient<IMovementFactory, MovementFactory>()
                .AddTransient<IAirplaneNavigationService, AirplaneNavigationService>()
                .AddScoped<Forward>()
                .AddScoped<IMovement, Forward>(s => s.GetService<Forward>())
                .AddScoped<Up>()
                .AddScoped<IMovement, Up>(s => s.GetService<Up>())
                .AddScoped<Down>()
                .AddScoped<IMovement, Down>(s => s.GetService<Down>())
                .AddScoped<Dive>()
                .AddScoped<IMovement, Dive>(s => s.GetService<Dive>())
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
