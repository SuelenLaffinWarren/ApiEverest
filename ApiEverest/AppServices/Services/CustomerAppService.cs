using AppModels;
using AutoMapper;
using DomainModels.Entities;
using DomainServices.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerAppService(ICustomerService customerService, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        public void Create(CustomerCreateDto customerEntity)
        {
            var customerDto = _mapper.Map<CustomerEntity>(customerEntity);
            _customerService.Create(customerDto);

        }

        public void Delete(long id)
        {
            _customerService.Delete(id);
        }

        public IEnumerable<CustomerResult> GetAll()
        {
            var getAllCustomers = _customerService.GetAll();
            return _mapper.Map<IEnumerable<CustomerResult>>(getAllCustomers);
        }

        public CustomerResult GetById(long id)
        {
            var getByIdCustomer = _customerService.GetById(id);
            return _mapper.Map<CustomerResult>(getByIdCustomer);
        }

        public void Update(CustomerUpdateDto customerEntity)
        {
            var customerDto = _mapper.Map<CustomerEntity>(customerEntity);
            _customerService.Update(customerDto);
        }
    }
}
