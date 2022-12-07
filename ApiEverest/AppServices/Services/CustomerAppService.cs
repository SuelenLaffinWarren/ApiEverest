using AppModels;
using AutoMapper;
using DomainModels.Entities;
using DomainServices.Services;
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

        public void Create(CustomerCreateDto customerCreateDto)
        {           
            var customerCreateDto = _mapper.Map<CustomerEntity>(customerCreateDto);
            _customerService.Create(customerCreateDto );
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

        public void Update(CustomerUpdateDto customerUpdateDto)
        {
            var _customerUpdateDto = _mapper.Map<CustomerEntity>(customerUpdateDto);
            _customerService.Update(_customerUpdateDto);
        }
    }
}
