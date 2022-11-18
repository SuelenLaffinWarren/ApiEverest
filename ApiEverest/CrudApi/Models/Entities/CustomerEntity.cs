using DocumentValidator;

namespace CustomerApi.Models.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        
        public string Cellphone { get; set; }
        public string CpfConfirmation { get; set; }
        public int Number { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public CustomerEntity(
        string fullName,
        string email,
        string emailConfirmation,
        string cpf,
        string cellphone,
        DateTime dateOfBirth,
        string emailSms,
        bool whatsapp,
        string country,
        string city,
        string postalCode,
        int number) 
        {
            FullName = fullName;
            Email = email;
            EmailConfirmation = emailConfirmation;
            EmailSms = emailSms;
            Cellphone = cellphone;
            DateOfBirth = dateOfBirth;
            EmailSms = emailSms;
            Cpf= cpf.Trim().Replace(".", "").Replace("-", ""); 
            Cellphone= cellphone;
            Country= country;
            City= city;
            PostalCode= postalCode;
            Whatsapp= whatsapp;
            Number= number;

        }
        

       
           

    }
}
