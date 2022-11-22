using ApiEverest.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<CustomerEntity> listCustomers = new();

        public void Create(CustomerEntity customerCreate)
        {
            if (listCustomers.Any(c => c.Email == customerCreate.Email))
            {
                throw new ArgumentException("Existing email");

            }

            if (listCustomers.Any(c => c.Cpf == customerCreate.Cpf))
            {
                throw new ArgumentException("Existing CPF");

            }
            customerCreate.Id = listCustomers.LastOrDefault()?.Id + 1 ?? 1;
            listCustomers.Add(customerCreate);
        }

        public bool Delete(long id)
        {
            var customer = GetById(id);
            listCustomers.Remove(customer);

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

        public bool Update(CustomerEntity updateCustomer)
        {
           

            if (listCustomers.Any(customer => customer.Email == updateCustomer.Email && customer.Id != updateCustomer.Id))
            {
                throw new ArgumentException($"Did not found customer for Email: {updateCustomer.Email}");
            }


            if (listCustomers.Any(customer => customer.Cpf == updateCustomer.Cpf && customer.Id != updateCustomer.Id))
            {
                throw new ArgumentException($"Did not found customer for Cpf: {updateCustomer.Cpf}");
            }

            var index = listCustomers.FindIndex(customer => customer.Id == updateCustomer.Id);
            if (index == -1) return false;

            updateCustomer.Id = listCustomers[index].Id;

            listCustomers[index] = updateCustomer;

            return true;

        }

        public bool customerDuplicate(CustomerEntity model)
        {

            if (listCustomers.Any(customer => customer.Cpf == model.Cpf))
            {
                throw new ArgumentException("Did not found customer for CPFs");
            }
            if (listCustomers.Any(customer => customer.Email == model.Email))
            {
                throw new ArgumentException("Did not found customer for Email");
            }
            return false;
        }
    }
}
