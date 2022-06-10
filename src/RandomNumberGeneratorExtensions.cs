using System;
using System.Security.Cryptography;
namespace ConsoleApp
{
    static class RandomNumberGeneratorExtensions
    {
        public static string GetBase64Extended(this RandomNumberGenerator rng,int byteSize)
        {
            var buf = new byte[byteSize];
            rng.GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
    }
}