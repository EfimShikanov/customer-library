using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerLibrary
{
    public class CustomerValidator
    {
        const int FirstNameMaxLength = 50;
        const int LastNameMaxLength = 50;
        const int AddressMinLength = 1;
        const int NotesMinLength = 1;
        const string PhoneFormat = @"^\+[1-9]\d{1,14}$";
        const string EmailFormat = "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$";

        public static List<string> Validate(Customer customer)
        {
            var errors = new List<string>();

            if (customer.FirstName.Length > FirstNameMaxLength)
            {
                errors.Add("First name is too long");
            }

            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                errors.Add("Last name can't be empty");
            }

            if (customer.LastName.Length > LastNameMaxLength)
            {
                errors.Add("Last name is too long");
            }

            if (customer.Addresses.Count < AddressMinLength)
            {
                errors.Add("Addresses can't be empty");
            }

            if (!Regex.IsMatch(customer.Phone, PhoneFormat))
            {
                errors.Add("Phone number has wrong format");
            }

            if (!Regex.IsMatch(customer.Email, EmailFormat))
            {
                errors.Add("Email has wrong format");
            }

            if (customer.Notes.Count < NotesMinLength)
            {
                errors.Add("Notes can't be empty");
            }

            return errors;
        }
    }
}
