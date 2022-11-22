﻿using ApiEverest.Entities;
using FluentValidation;

namespace CustomerApi.Validators
{
    public class CustomerRulesValidator : AbstractValidator<CustomerEntity>
    {
        public CustomerRulesValidator()
        {
            RuleFor(customer => customer.FullName)
                .NotEmpty()
                .WithMessage("FullName is required")
                .MinimumLength(5).WithMessage("Minimum length must be 5 caracteres");

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email format");

            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .Must(isValidCpf)
                .WithMessage("Cpf is invalid");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .WithMessage("date of birth must be informed")
                .Must(OverAgeCustomer).WithMessage("Customer must be at least 18 years old");

            RuleFor(customer => customer.Country)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(40);

            RuleFor(customer => customer.City)
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(40);

            RuleFor(customer => customer.Cellphone)
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(16);
               
                

            RuleFor(c => c.PostalCode)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(9);


        }
        private static bool OverAgeCustomer(DateTime dateOfBirth)
        {
            return dateOfBirth <= DateTime.Now.AddYears(-18);
        }

        public bool isValidCpf(string cpf)
        {
            int[] multiplierOne = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierTwo = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temCpf;
            string Digit;
            int rest;
            int sum = 0;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            temCpf = cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                sum += int.Parse(temCpf[i].ToString()) * multiplierOne[i];
            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            Digit = rest.ToString();
            temCpf = temCpf + Digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(temCpf[i].ToString()) * multiplierTwo[i];
            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            Digit = Digit + rest.ToString();

            return cpf.EndsWith(Digit);
        }
    }
}
