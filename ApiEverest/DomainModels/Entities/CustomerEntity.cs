
using System;

namespace DomainModels.Entities
{
    public class CustomerEntity : IEntity
    {
        public CustomerEntity(
            string fullName,
            string email,
            string emailConfirmation,
            string cpf,
            string cellphone,
            DateTime dateOfBirth,
            bool emailSms,
            bool whatsapp,
            string country,
            string city,
            string postalCode,
            int number
        )
        {
            FullName = fullName;
            Email = email;
            EmailConfirmation = emailConfirmation;
            EmailSms = emailSms;
            Cellphone = cellphone;
            DateOfBirth = dateOfBirth;
            EmailSms = emailSms;
            Cpf = cpf.CpfFormatter();
            Cellphone = cellphone;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Whatsapp = whatsapp;
            Number = number;
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public int Number { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public long Id { get; set; }
    }
}
