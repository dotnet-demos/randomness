using EasyConsole;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleApp
{
    internal class MenuService : BackgroundService
    {
        public RandomOption Option1 { get; init; }
        public MenuService(RandomOption opt1)
        {
            Option1 = opt1;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var menu = new Menu()
                .Add("Randon class - Display 10 random numbers", async (token) => await Option1.Display10RandomNumbers())
                .Add("Randon class - Display 10 random numbers with seed 25", async (token) => await Option1.Display10RandomNumbersWithSeed25())
                .AddSync("Exit", () => Environment.Exit(0));
            await menu.Display(CancellationToken.None);
            await base.StartAsync(stoppingToken);
        }
    }
}