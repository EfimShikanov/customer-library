using System.Collections.Generic;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class CustomerValidatorTests
    {
        [Fact]
        public void ShouldReturnFirstNameIsTooLong()
        {
            Customer customer = new Customer { FirstName = new string('f', 51) };

            List<string> result = CustomerValidator.Validate(customer);

            Assert.Contains("First name is too long", result);
        }

        [Fact]
        public void ShouldReturnLastNameIsRequired()
        {
            Customer customer = new Customer("Firstname", "", new List<Address>(), "phone", "email", new List<string>(), 0);

            List<string> result = CustomerValidator.Validate(customer);

            Assert.Contains("Last name can't be empty", result);
        }

        [Fact]
        public void ShouldReturnLastNameIsTooLong()
        {
            Customer customer = new Customer("Firstname", new string('f', 51), new List<Address>(), "phone", "email", new List<string>(), 0);

            List<string> result = CustomerValidator.Validate(customer);

            Assert.Contains("Last name is too long", result);
        }

        [Fact]
        public void ShouldReturnAddressesCantBeEmpty()
        {
            Customer customer = new Customer("Firstname", "Lastname", new List<Address>(), "phone", "email", new List<string>(), 0);

            List<string> result = CustomerValidator.Validate(customer);

            Assert.Contains("Addresses can't be empty", result);
        }

        [Fact]
        public void ShouldReturnPhoneFormatInvalid()
        {
            Customer customer = new Customer("Firstname", "Lastname", new List<Address>(), "phone", "email", new List<string>(), 0);

            List<string> result = CustomerValidator.Validate(customer);

            Assert.Contains("Phone number has wrong format", result);
        }

        [Fact]
        public void ShouldReturnEmailFormatInvalid()
        {
            Customer customer = new Customer("Firstname", "Lastname", new List<Address>(), "phone", "email", new List<string>(), 0);

            List<string> result = CustomerValidator.Validate(customer);

            Assert.Contains("Email has wrong format", result);
        }

        [Fact]
        public void ShouldReturnNotesCantBeEmpty()
        {
            Customer customer = new Customer("Firstname", "Lastname", new List<Address>(), "phone", "email", new List<string>(), 0);

            List<string> result = CustomerValidator.Validate(customer);

            Assert.Contains("Notes can't be empty", result);
        }
    }
}
