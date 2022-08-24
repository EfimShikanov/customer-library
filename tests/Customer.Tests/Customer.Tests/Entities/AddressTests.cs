using Xunit;

namespace CustomerLibrary.Tests
{
    public class AddressTests
    {
        [Fact]
        public void ShouldBeAbleToCreateEmptyAddress()
        {
            Address address = new Address();

            Assert.NotNull(address);
            Assert.Null(address.AddressLine);
            Assert.Null(address.AddressLine2);
            Assert.Equal(AddressType.Unknown, address.Type);
            Assert.Null(address.City);
            Assert.Null(address.PostalCode);
            Assert.Null(address.State);
            Assert.Null(address.Country);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var address = new Address
            {
                AddressLine = "addressline1",
                AddressLine2 = "addressline2",
                Type = AddressType.Shipping,
                City = "city",
                PostalCode = "postalcode",
                State = "state",
                Country = "country"
            };

            Assert.NotNull(address);
            Assert.Equal("addressline1", address.AddressLine);
            Assert.Equal("addressline2", address.AddressLine2);
            Assert.Equal(AddressType.Shipping, address.Type);
            Assert.Equal("city", address.City);
            Assert.Equal("postalcode", address.PostalCode);
            Assert.Equal("state", address.State);
            Assert.Equal("country", address.Country);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddressWithConstructor()
        {
            var address = new Address("addressline1", "addressline2", AddressType.Shipping, "city", "postalcode", "state", "country");

            Assert.NotNull(address);
            Assert.Equal("addressline1", address.AddressLine);
            Assert.Equal("addressline2", address.AddressLine2);
            Assert.Equal(AddressType.Shipping, address.Type);
            Assert.Equal("city", address.City);
            Assert.Equal("postalcode", address.PostalCode);
            Assert.Equal("state", address.State);
            Assert.Equal("country", address.Country);
        }
    }
}
