namespace AppModels
{
    public class CustomerResultDto
    {
        protected CustomerResultDto() { }

        public CustomerResultDto(
        long Id,
        string fullName,
        string email,
        string cpf,
        string cellphone,
        string country,
        string city,
        string postalCode)
        {
            Id = Id;
            FullName = fullName;
            Email = email;
            Cellphone = cellphone;
            Cpf = cpf;
            Cellphone = cellphone;
            Country = country;
            City = city;
            PostalCode = postalCode;
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public long Id { get; set; }
    }
}

