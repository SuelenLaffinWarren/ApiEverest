using CustomerApi.Models.Entities;

namespace CustomerApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerEntity> listCustomers = new List<CustomerEntity>();

        public bool Create(CustomerEntity model)
        {
            model.Id = listCustomers.LastOrDefault()?.Id + 1 ?? 1;
            listCustomers.Add(model);   
            return true;
        }

        public bool Delete(long id)
        {
           int index = listCustomers.FindIndex(customer => customer.Id == id);
            listCustomers.RemoveAt(index);
            return true;
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            return listCustomers;
        }

        public CustomerEntity? GetById(long id)
        {
          return listCustomers.Find(customer => customer.Id == id);
        }

        public bool Update(CustomerEntity model)
        {
            var updateCustomer = GetById(model.Id);
            if (updateCustomer == null)
            {
                return false;
            }

            if(customerDuplicate(model)) 
            { 
                var index = listCustomers.IndexOf(updateCustomer);

                listCustomers[index] = model;

                return true;
            }

            return false;

        }

        public bool customerDuplicate(CustomerEntity model)
        {
            if (listCustomers.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email))
            {
                return true;
            }
            return false;
        }
    }
}
