using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class RandomNumberGeneratorOption
    {
        IDependency dependency;
        ILogger<RandomNumberGeneratorOption> logger;
        public RandomNumberGeneratorOption(IDependency dep, ILogger<RandomNumberGeneratorOption> logger)
        {
            dependency = dep;
            this.logger = logger;
        }
        async internal Task Execute()
        {
            logger.LogTrace($"{nameof(RandomNumberGeneratorOption)} : Start");
            await Task.Delay(1);
            logger.LogInformation($"Value from {nameof(IDependency)} is '{ dependency.Foo()}'");
        }
    }
}