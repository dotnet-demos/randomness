using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        async internal Task Display1RandomInBase64()
        {
            logger.LogTrace($"{nameof(Display1RandomInBase64)} : Start");

            var rng = RandomNumberGenerator.Create();
            string randomBase64String = rng.GetBase64Extended(byteSize:5);

            logger.LogInformation($"{nameof(Display1RandomInBase64)} - Random base64 :{randomBase64String}");
            await Task.Delay(1);// Just to satisfy compiler to avoid missing await warning
        }
        async internal Task Display10RandomsInBase64()
        {
            logger.LogTrace($"{nameof(Display10RandomsInBase64)} : Start");

            var rng = RandomNumberGenerator.Create();
            var randomNumbers = Enumerable.Range(0, 10)
                .Select(index => rng.GetBase64Extended(5))
                .ToArray();
            string randomNumberString = string.Join(",", randomNumbers);

            logger.LogInformation($"{nameof(Display10RandomsInBase64)} - Random numbers :{randomNumberString}");
            await Task.Delay(1); // Just to satisfy compiler to avoid missing await warning
        }
        async internal Task Display1RandomUsingAesCryptoServiceProviderInBase64()
        {
            logger.LogTrace($"{nameof(Display1RandomUsingAesCryptoServiceProviderInBase64)} : Start");
            var rng = RandomNumberGenerator.Create("AesCryptoServiceProvider");
            logger.LogInformation($"{nameof(Display1RandomUsingAesCryptoServiceProviderInBase64)} - Random base64 :{rng.GetBase64Extended(5)}");
            await Task.Delay(1);
        }
    }
}