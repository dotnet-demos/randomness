using EasyConsole;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleApp
{
    internal class MenuService : BackgroundService
    {
        RandomOption randomOption;
        RandomNumberGeneratorOption randomNumberGeneratorOption;
        public MenuService(RandomOption opt1, RandomNumberGeneratorOption randomNumberGeneratorOption)
        {
            this.randomOption = opt1;
            this.randomNumberGeneratorOption = randomNumberGeneratorOption;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var menu = new Menu()
                .Add("Randon class - Display 10 random numbers", async (token) => await randomOption.Display10RandomNumbers())
                .Add("Randon class - Display 10 random numbers with seed 25", async (token) => await randomOption.Display10RandomNumbersWithSeed25())
                .Add("RandomNumberGenerator class - Display 1 random in Base64", async (token) => await randomNumberGeneratorOption.Display1RandomInBase64())
                .Add("RandomNumberGenerator class - Display 10 random in Base64", async (token) => await randomNumberGeneratorOption.Display10RandomsInBase64())
                .Add("RandomNumberGenerator class - Display 1 random using AesCryptoServiceProvider in Base64 (Exception)", async (token) => await randomNumberGeneratorOption.Display1RandomUsingAesCryptoServiceProviderInBase64())

                .AddSync("Exit", () => Environment.Exit(0));
            await menu.Display(CancellationToken.None);
            await base.StartAsync(stoppingToken);
        }
    }
}