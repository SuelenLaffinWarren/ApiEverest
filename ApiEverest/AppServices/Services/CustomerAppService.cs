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

        public long Create(CustomerCreateDto customerCreateDto)
        {
            var customerDto = _mapper.Map<CustomerEntity>(customerCreateDto);
            return _customerService.Create(customerDto);
        }

        public void Delete(long id)
        {
            _customerService.Delete(id);
        }

        public IEnumerable<CustomerResultDto> GetAll()
        {
            var getAllCustomers = _customerService.GetAll();
            return _mapper.Map<IEnumerable<CustomerResultDto>>(getAllCustomers);
        }

        public CustomerResultDto GetById(long id)
        {
            var getByIdCustomer = _customerService.GetById(id);
            return _mapper.Map<CustomerResultDto>(getByIdCustomer);
        }

        public void Update(CustomerUpdateDto customerUpdateDto, long id)
        {
            var customerDto = _mapper.Map<CustomerEntity>(customerUpdateDto);
            customerDto.Id= id;
            _customerService.Update(customerDto);
        }
    }
}
