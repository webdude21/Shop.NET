namespace Shop.Net.Resources
{
    using System.Collections.Generic;
    using System.IO;

    public class CountryLoader
    {
        private readonly string countryFilePath;

        public CountryLoader(string countryFilePath)
        {
            this.countryFilePath = countryFilePath;
        }

        public Dictionary<string, string> RetrieveCountries()
        {
            var textFileStream = new StreamReader(this.countryFilePath);
            var countriesDict = new Dictionary<string, string>();

            using (textFileStream)
            {
                var currentCountry = textFileStream.ReadLine();

                while (currentCountry != null)
                {
                    var keyValuePair = currentCountry.Split(';');
                    if (!countriesDict.ContainsKey(keyValuePair[0]))
                    {
                        countriesDict.Add(keyValuePair[0], keyValuePair[1]);
                    }

                    currentCountry = textFileStream.ReadLine();
                }
            }

            return countriesDict;
        }
    }
}