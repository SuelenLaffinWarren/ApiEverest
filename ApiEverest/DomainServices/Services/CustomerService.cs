using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerEntity> listCustomers = new();

        public long Create(CustomerEntity customerCreate)
        {
            CustomerDuplicate(customerCreate);
            customerCreate.Id = listCustomers.LastOrDefault()?.Id + 1 ?? 1;
            listCustomers.Add(customerCreate);
            return customerCreate.Id;
        }
        
        public void Delete(long id)
        {
            var customer = GetById(id);
            listCustomers.Remove(customer);
        }
        
        public IEnumerable<CustomerEntity> GetAll()
        {
            return listCustomers;
        }
        
        public CustomerEntity GetById(long id)
        {
            var response = listCustomers.FirstOrDefault(customer => customer.Id == id);

            if (response == null) throw new ArgumentNullException($"Customer with id: {id} was not found");

            return response;
        }
        public void Update(CustomerEntity updateCustomer)
        {
            CustomerDuplicate(updateCustomer);
            var index = listCustomers.FindIndex(customer => customer.Id == updateCustomer.Id);

            if (index == -1)
                throw new ArgumentNullException($"Customer with id {updateCustomer.Id} not found");

            listCustomers[index] = updateCustomer;
        }
        
        private void CustomerDuplicate(CustomerEntity model)
        {
            if (listCustomers.Any(customer => customer.Cpf == model.Cpf && customer.Id != model.Id))
                throw new ArgumentException("This CPF already exists");

            if (listCustomers.Any(customer => customer.Email == model.Email && customer.Id != model.Id))
                throw new ArgumentException("This email already exists");
        }
    }
}
