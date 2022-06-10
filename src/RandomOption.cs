using EasyConsole;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class RandomOption
    {
        IDependency dependency;
        ILogger<RandomOption> logger;
        public RandomOption(IDependency dep, ILogger<RandomOption> logger)
        {
            dependency = dep;
            this.logger = logger;
        }
        async internal Task Display10RandomNumbers()
        {
            logger.LogTrace($"{nameof(Display10RandomNumbers)} : Start");
            Random random = new Random();
            var randomNumbers = Enumerable.Range(0, 10)
                .Select(i => random.Next())
                .ToArray();
            string randomNumberString = string.Join(",", randomNumbers);
            logger.LogInformation($"Random numbers :{randomNumberString}");
            await Task.Delay(1);
        }
        async internal Task Display10RandomNumbersWithSeed25()
        {
            logger.LogTrace($"{nameof(Display10RandomNumbersWithSeed25)} : Start");
            Random random = new Random(25);
            var randomNumbers = Enumerable.Range(0, 10)
                .Select(i => random.Next())
                .ToArray();
            string randomNumberString = string.Join(",", randomNumbers);
            logger.LogInformation($"Random numbers :{randomNumberString}");
            await Task.Delay(1);
        }
    }
}