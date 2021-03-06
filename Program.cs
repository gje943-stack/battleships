using BattleshipEngine.Factories;
using BattleshipEngine.Models;
using BattleshipEngine.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BattleshipEngine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IEngine, Engine>();
                    services.AddTransient<IShipPositioner, ShipPositioner>();
                    services.AddTransient<ICoordsGenerator, CoordsGenerator>();
                    services.AddSingleton<IShipFactory, ShipFactory>();
                    services.AddTransient<IPlayerFactory, PlayerFactory>();
                    services.AddTransient<IBoardFactory, BoardFactory>();
                    services.AddTransient<IGameDisplay, GameDisplay>();
                    services.AddTransient<IPlayerStats, PlayerStats>();
                    services.AddTransient<IGameDisplayFactory, GameDisplayFactory>();
                })
                .Build();
            var app = ActivatorUtilities.GetServiceOrCreateInstance<IEngine>(host.Services);
        }
    }
}