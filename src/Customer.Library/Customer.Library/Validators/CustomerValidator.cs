using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentValidation;

namespace CustomerLibrary
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        const string FirstNameTooLong = "First name is too long";
        const string LastNameTooLong = "Last name is too long";
        const string LastNameEmpty = "Last name can't be empty";
        const string AddressEmpty = "Addresses can't be empty";
        const string PhoneFormatInvalid = "Phone number has wrong format";
        const string EmailFormatInvalid = "Email has wrong format";
        const string NotesEmpty = "Notes can't be empty";

        const int FirstNameMaxLength = 50;
        const int LastNameMaxLength = 50;
        const int AddressMinLength = 1;
        const int NotesMinLength = 1;
        const string PhoneFormat = @"^\+[1-9]\d{1,14}$";
        const string EmailFormat = "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$";

        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName)
                .MaximumLength(FirstNameMaxLength).WithMessage(FirstNameTooLong);

            RuleFor(customer => customer.LastName)
                .NotEmpty().WithMessage(LastNameEmpty)
                .MaximumLength(LastNameMaxLength).WithMessage(LastNameTooLong);

            RuleFor(customer => customer.Addresses)
                .NotEmpty().WithMessage(AddressEmpty);

            RuleFor(customer => customer.Phone)
                .Matches(PhoneFormat).WithMessage(PhoneFormatInvalid);

            RuleFor(customer => customer.Email)
                .Matches(EmailFormat).WithMessage(EmailFormatInvalid);

            RuleFor(customer => customer.Notes)
                .NotEmpty().WithMessage(NotesEmpty);
        }
    }
}
