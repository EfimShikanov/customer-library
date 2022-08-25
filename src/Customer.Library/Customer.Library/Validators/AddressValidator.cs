using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerLibrary
{
    public class AddressValidator : AbstractValidator<Address>
    {
        const string AddressEmpty = "Address Line can't be empty";
        const string AddressTooLong = "Address Line is too long";
        const string Address2TooLong = "Address Line 2 is too long";
        const string CityEmpty = "City can't be empty";
        const string CityTooLong = "City is too long";
        const string PostalCodeEmpty = "Postal Code can't be empty";
        const string PostalCodeTooLong = "Postal Code is too long";
        const string StateEmpty = "State can't be empty";
        const string StateTooLong = "State is too long";
        const string CountryInvalid = "Country accepts only United States or Canada";

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

        public AddressValidator()
        {
            RuleFor(address => address.AddressLine)
                .NotEmpty().WithMessage(AddressEmpty)
                .MaximumLength(AddressLineMaxLength).WithMessage(AddressTooLong);

            RuleFor(address => address.AddressLine2)
                .MaximumLength(AddressLine2MaxLength).WithMessage(Address2TooLong);

            RuleFor(address => address.City)
                .NotEmpty().WithMessage(CityEmpty)
                .MaximumLength(CityMaxLength).WithMessage(CityTooLong);

            RuleFor(address => address.PostalCode)
                .NotEmpty().WithMessage(PostalCodeEmpty)
                .MaximumLength(PostalCodeMaxLength).WithMessage(PostalCodeTooLong);

            RuleFor(address => address.State)
                .NotEmpty().WithMessage(StateEmpty)
                .MaximumLength(StateMaxLength).WithMessage(StateTooLong);

            RuleFor(address => address.Country)
                .Must(country => AvailableCountries.Contains(country, StringComparer.OrdinalIgnoreCase)).WithMessage(CountryInvalid);
        }
    }
}
