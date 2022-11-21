using ApiEverest.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerEntity> listCustomers = new();

        public void Create(CustomerEntity model)
        {
            model.Id = listCustomers.LastOrDefault()?.Id + 1 ?? 1;

            if (!listCustomers.Any() || customerDuplicate(model))
            {
                throw new ArgumentException();

            }
            listCustomers.Add(model);
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
          var response = listCustomers.FirstOrDefault(customer => customer.Id == id);

        if (response == null) throw new ArgumentNullException($"Customer with id: {id} was not found");

         return response;   
        }

        public bool Update(CustomerEntity model)
        {
            var updateCustomer = GetById(model.Id);
            
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
            
            if (listCustomers.Any(customer => customer.Cpf == model.Cpf) )
            {
                throw new ArgumentException("Did not found customer for CPFs");
            }
            if(listCustomers.Any(customer => customer.Email == model.Email))
            {
                throw new ArgumentException("Did not found customer for Email");
            }
            return false;
        }
    }
}
