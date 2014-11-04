namespace Shop.Net.Resources
{
    using System;
    using System.Collections.Generic;

    using Shop.Net.Resources.Properties;

    public class CountryLoader
    {
        private readonly string countryList;

        public CountryLoader(string countryList)
        {
            this.countryList = countryList;
        }

        public CountryLoader()
            : this(Resources.Countries)
        {
        }

        public Dictionary<string, string> RetrieveCountries()
        {
            var countries = this.countryList.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var countriesDict = new Dictionary<string, string>();

            foreach (var country in countries)
            {
                var keyValuePair = country.Split(';');
                if (!countriesDict.ContainsKey(keyValuePair[0]))
                {
                    countriesDict.Add(keyValuePair[0], keyValuePair[1]);
                }
            }

            return countriesDict;
        }
    }
}