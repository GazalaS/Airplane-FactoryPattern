// See https://aka.ms/new-console-template for more information
using Airplane.Extensions;
using Airplane.Services;
using Microsoft.Extensions.DependencyInjection;

string fileName = @"C:\Input\commands.txt";

var serviceProvider = ServicesExtensions.BuildServiceProvider();

var airplaneNavigationService = serviceProvider.GetService<IAirplaneNavigationService>();
airplaneNavigationService?.Navigate(fileName);
Console.ReadLine();