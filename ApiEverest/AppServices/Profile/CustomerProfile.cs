using AppModels;
using AutoMapper;
using DomainModels.Entities;


namespace ApiEverest.Mappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CustomerEntity, CustomerCreateDto>();
            CreateMap<CustomerEntity, CustomerUpdateDto>();
        }
    }
}
