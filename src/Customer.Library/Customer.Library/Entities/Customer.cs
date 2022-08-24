using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerLibrary
{
    public class Customer : Person
    {
        public List<Address> Addresses { get; set; } = new List<Address>();
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Notes { get; set; } = new List<string>();
        public decimal? TotalPurchasesAmount { get; set; }

        public Customer() { }

        public Customer(string firstName, string lastName, List<Address> addresses, string phone, string email, List<string> notes, decimal? totalPurchasesAmount) : base(firstName, lastName)
        {
            Addresses = addresses;
            Phone = phone;
            Email = email;
            Notes = notes;
            TotalPurchasesAmount = totalPurchasesAmount;
        }
        
    }
}
