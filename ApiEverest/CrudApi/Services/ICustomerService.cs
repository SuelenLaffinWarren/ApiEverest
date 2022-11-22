﻿using ApiEverest.Entities;

namespace CustomerApi.Services
{
    public interface ICustomerService 
    {
        void Create(CustomerEntity model);
        bool Update(CustomerEntity model);
        bool Delete(long id);

        IEnumerable<CustomerEntity> GetAll();

        CustomerEntity? GetById(long id);

    }
}
