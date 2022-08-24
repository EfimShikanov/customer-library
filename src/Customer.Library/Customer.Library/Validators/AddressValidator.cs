using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerLibrary
{
    public class AddressValidator
    {
        const int AddressLineMaxLength = 100;
        const int AddressLine2MaxLength = 100;
        const int CityMaxLength = 50;
        const int PostalCodeMaxLength = 6;
        const int StateMaxLength = 20;
        static readonly string[] AvailableCountries =
        {
            "United States",
            "Canada"
        };

        public static List<string> Validate(Address address)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(address.AddressLine))
            {
                errorList.Add("Address Line can't be empty");
            }
            else if (address.AddressLine.Length > AddressLineMaxLength)
            {
                errorList.Add("Address Line is too long");
            }

            if (!string.IsNullOrEmpty(address.AddressLine2) && address.AddressLine2.Length > AddressLine2MaxLength)
            {
                errorList.Add("Address Line 2 is too long");
            }

            if (string.IsNullOrWhiteSpace(address.City))
            {
                errorList.Add("City can't be empty");
            }
            else if (address.City.Length > CityMaxLength)
            {
                errorList.Add("City is too long");
            }

            if (string.IsNullOrWhiteSpace(address.PostalCode))
            {
                errorList.Add("Postal Code can't be empty");
            }
            else if (address.PostalCode.Length > PostalCodeMaxLength)
            {
                errorList.Add("Postal Code is too long");
            }

            if (string.IsNullOrWhiteSpace(address.State))
            {
                errorList.Add("State can't be empty");
            }
            else if (address.State.Length > StateMaxLength)
            {
                errorList.Add("State is too long");
            }

            if (!AvailableCountries.Contains(address.Country, StringComparer.OrdinalIgnoreCase))
            {
                errorList.Add("City accepts only United States or Canada");
            }

            return errorList;
        }
    }
}
