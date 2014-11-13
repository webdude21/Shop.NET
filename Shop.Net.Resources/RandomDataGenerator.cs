namespace Shop.Net.Resources
{
    using System;

    using Shop.Net.Resources.Contracts;

    public class RandomDataGenerator : IRandomDataGenerator
    {
        private const string AllAlphaNumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";

        private const string BigLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private const string Numeric = "1234567890";

        private const string UrlSafeLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_";

        private const string AllLeters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private const string AllLetersWithSpaces = "abcdefghi jklmn opqrst uvwxyzABCDEFGHIJKL MNOPQRSTU VWXYZ1 234567890";

        private static RandomDataGenerator instance;

        private readonly Random random;

        public RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static RandomDataGenerator Instance
        {
            get
            {
                return instance ?? (instance = new RandomDataGenerator());
            }
        }

        public string GetStringExact(int length, string charsToUse)
        {
            var result = new char[length];

            for (var i = 0; i < length; i++)
            {
                result[i] = charsToUse[this.random.Next(0, charsToUse.Length)];
            }

            return new string(result);
        }

        public string GetStringExact(int length)
        {
            return this.GetStringExact(length, AllLetersWithSpaces);
        }

        public DateTime GeneraDateTime()
        {
            return new DateTime(this.GetInt(2013, 2015), this.GetInt(1, 11), this.GetInt(1, 27));
        }

        public string GetString(int min, int max)
        {
            return this.GetStringExact(this.random.Next(min, max + 1), AllLetersWithSpaces);
        }

        public string GetString(int min, int max, string charsToUse)
        {
            return this.GetStringExact(this.random.Next(min, max + 1), charsToUse);
        }

        public string GetUrlSafeString(int min, int max)
        {
            return this.GetStringExact(this.random.Next(min, max + 1), UrlSafeLetters);
        }

        public int GetInt(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public double GetDouble()
        {
            return this.random.NextDouble();
        }

        public bool GetChance(int percent)
        {
            return this.random.Next(0, 101) <= percent;
        }
    }
}