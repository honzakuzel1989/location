using System;
using System.Collections.Generic;
using System.Text;

namespace location.Core.Entities
{
    public class Address
    {
        public Address(string houseNumber, string road, string suburb, string city, string postCode, string country, string countryCode)
        {
            HouseNumber = houseNumber;
            Road = road;
            Suburb = suburb;
            City = city;
            PostCode = postCode;
            Country = country;
            CountryCode = countryCode;
        }

        public string HouseNumber { get; }
        public string Road { get; }
        public string Suburb { get; }
        public string City { get; }
        public string PostCode { get; }
        public string Country { get; }
        public string CountryCode { get; }
    }
}
