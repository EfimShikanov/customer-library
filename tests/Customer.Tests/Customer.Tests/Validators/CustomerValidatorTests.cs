using FluentValidation.TestHelper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class CustomerValidatorTests
    {
        public CustomerValidator validator = new CustomerValidator();

        [Fact]
        public void ShouldReturnFirstNameIsTooLong()
        {
            Customer customer = new Customer { FirstName = new string('f', 51) };

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.FirstName).WithErrorMessage("First name is too long");
        }

        [Fact]
        public void ShouldReturnLastNameIsRequired()
        {
            Customer customer = new Customer("Firstname", "", new List<Address>(), "phone", "email", new List<string>(), 0);

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.LastName).WithErrorMessage("Last name can't be empty");
        }

        [Fact]
        public void ShouldReturnLastNameIsTooLong()
        {
            Customer customer = new Customer("Firstname", new string('f', 51), new List<Address>(), "phone", "email", new List<string>(), 0);

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.LastName).WithErrorMessage("Last name is too long");
        }

        [Fact]
        public void ShouldReturnAddressesCantBeEmpty()
        {
            Customer customer = new Customer("Firstname", "Lastname", new List<Address>(), "phone", "email", new List<string>(), 0);

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.Addresses).WithErrorMessage("Addresses can't be empty");
        }

        [Fact]
        public void ShouldReturnPhoneFormatInvalid()
        {
            Customer customer = new Customer("Firstname", "Lastname", new List<Address>(), "phone", "email", new List<string>(), 0);

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.Phone).WithErrorMessage("Phone number has wrong format");
        }

        [Fact]
        public void ShouldReturnEmailFormatInvalid()
        {
            Customer customer = new Customer("Firstname", "Lastname", new List<Address>(), "phone", "email", new List<string>(), 0);

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.Email).WithErrorMessage("Email has wrong format");
        }

        [Fact]
        public void ShouldReturnNotesCantBeEmpty()
        {
            Customer customer = new Customer("Firstname", "Lastname", new List<Address>(), "phone", "email", new List<string>(), 0);

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.Notes).WithErrorMessage("Notes can't be empty");
        }
    }
}
