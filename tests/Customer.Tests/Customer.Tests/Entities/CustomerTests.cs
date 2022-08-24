using System;
using System.Collections.Generic;
using Xunit;

namespace CustomerLibrary.Tests
{
    public class CustomerTest
    {
        [Fact]
        public void ShouldBeAbleToCreateEmptyCustomer()
        {
            Customer customer = new Customer();

            Assert.NotNull(customer);
            Assert.Equal(string.Empty, customer.FirstName);
            Assert.Equal(string.Empty, customer.LastName);
            Assert.Equal(string.Empty, customer.Email);
            Assert.Equal(string.Empty, customer.Phone);
            Assert.Equal(new List<Address>(), customer.Addresses);
            Assert.Equal(new List<string>(), customer.Notes);
            Assert.Null(customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Customer customer = new Customer
            {
                FirstName = "Firstname",
                LastName = "Lastname",
                Addresses = new List<Address>(),
                Phone = "123456",
                Email = "email@email.com",
                Notes = new List<string>(),
                TotalPurchasesAmount = 100
            };

            Assert.NotNull(customer);
            Assert.Equal("Firstname", customer.FirstName);
            Assert.Equal("Lastname", customer.LastName);
            Assert.Equal("email@email.com", customer.Email);
            Assert.Equal("123456", customer.Phone);
            Assert.Equal(new List<Address>(), customer.Addresses);
            Assert.Equal(new List<string>(), customer.Notes);
            Assert.Equal(100, customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomerWithConstructor()
        {
            Customer customer = new Customer("Firstname", "Lastname", new List<Address>(), "123456", "email@email.com", new List<string>(), 100);

            Assert.NotNull(customer);
            Assert.Equal("Firstname", customer.FirstName);
            Assert.Equal("Lastname", customer.LastName);
            Assert.Equal("email@email.com", customer.Email);
            Assert.Equal("123456", customer.Phone);
            Assert.Equal(new List<Address>(), customer.Addresses);
            Assert.Equal(new List<string>(), customer.Notes);
            Assert.Equal(100, customer.TotalPurchasesAmount);
        }
    }
}
