using Xunit;

namespace CustomerLibrary.Tests
{
    public class AddressValidatorTests
    {
        [Fact]
        public void ShouldReturnAddress1CantBeEmpty()
        {
            Address address = new Address("", "address2", AddressType.Billing, "city", "postal", "state", "country");

            var result = AddressValidator.Validate(address);

            Assert.Contains("Address Line can't be empty", result);
        }

        [Fact]
        public void ShouldReturnAddress1IsTooLong()
        {
            Address address = new Address(new string('a', 101), "address2", AddressType.Billing, "city", "postal", "state", "country");

            var result = AddressValidator.Validate(address);

            Assert.Contains("Address Line is too long", result);
        }

        [Fact]
        public void ShouldReturnAddress2IsTooLong()
        {
            Address address = new Address("address1", new string('a', 101), AddressType.Billing, "city", "postal", "state", "country");

            var result = AddressValidator.Validate(address);

            Assert.Contains("Address Line 2 is too long", result);
        }

        [Fact]
        public void ShouldReturnCityCantBeEmpty()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "", "postal", "state", "country");

            var result = AddressValidator.Validate(address);

            Assert.Contains("City can't be empty", result);
        }

        [Fact]
        public void ShouldReturnCityIsTooLong()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, new string('c', 51), "postal", "state", "country");

            var result = AddressValidator.Validate(address);

            Assert.Contains("City is too long", result);
        }

        [Fact]
        public void ShouldReturnPostalCodeCantBeEmpty()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "city", "", "state", "country");

            var result = AddressValidator.Validate(address);

            Assert.Contains("Postal Code can't be empty", result);
        }

        [Fact]
        public void ShouldReturnPostalCodeIsTooLong()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "city", new string('p', 7), "state", "country");

            var result = AddressValidator.Validate(address);

            Assert.Contains("Postal Code is too long", result);
        }

        [Fact]
        public void ShouldReturnStateCantBeEmpty()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "city", "postal", "", "country");

            var result = AddressValidator.Validate(address);

            Assert.Contains("State can't be empty", result);
        }

        [Fact]
        public void ShouldReturnStateIsTooLong()
        {
            Address address = new Address("address1", "address2", AddressType.Billing, "city", "postal", new string('s', 21), "country");

            var result = AddressValidator.Validate(address);

            Assert.Contains("State is too long", result);
        }
    }
}