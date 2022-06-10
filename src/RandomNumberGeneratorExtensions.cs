using System;
using System.Security.Cryptography;
namespace ConsoleApp
{
    static class RandomNumberGeneratorExtensions
    {
        public static string GetBase64Extended(this RandomNumberGenerator rng)
        {
            var buf = new byte[5];
            rng.GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
    }
}