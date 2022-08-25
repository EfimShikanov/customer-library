using FluentValidation.TestHelper;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class AddressValidatorTests
    {
        public AddressValidator validator = new AddressValidator();

        [Fact]
        public void ShouldReturnAddress1CantBeEmpty()
        {
            Address address = new Address("", "address2", AddressType.Billing, "city", "postal", "state", "country");

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.AddressLine).WithErrorMessage("Address Line can't be empty");
        }

        [Fact]
        public void ShouldReturnAddress1IsTooLong()
        {
            Address address = new Address(new string('a', 101), "address2", AddressType.Billing, "city", "postal", "state", "country");

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.AddressLine).WithErrorMessage("Address Line is too long");
        }

        [Fact]
        public void ShouldReturnAddress2IsTooLong()
        {
            Address address = new Address("address1", new string('a', 101), AddressType.Billing, "city", "postal", "state", "country");

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.AddressLine2).WithErrorMessage("Address Line 2 is too long");
        }

        [Fact]
        public void ShouldReturnCityCantBeEmpty()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "", "postal", "state", "country");

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.City).WithErrorMessage("City can't be empty");
        }

        [Fact]
        public void ShouldReturnCityIsTooLong()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, new string('c', 51), "postal", "state", "country");

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.City).WithErrorMessage("City is too long");
        }

        [Fact]
        public void ShouldReturnPostalCodeCantBeEmpty()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "city", "", "state", "country");

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.PostalCode).WithErrorMessage("Postal Code can't be empty");
        }

        [Fact]
        public void ShouldReturnPostalCodeIsTooLong()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "city", new string('p', 7), "state", "country");

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.PostalCode).WithErrorMessage("Postal Code is too long");
        }

        [Fact]
        public void ShouldReturnStateCantBeEmpty()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "city", "postal", "", "country");

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.State).WithErrorMessage("State can't be empty");
        }

        [Fact]
        public void ShouldReturnStateIsTooLong()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "city", "postal", new string('s', 21), "country");

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.State).WithErrorMessage("State is too long");
        }
    }
}