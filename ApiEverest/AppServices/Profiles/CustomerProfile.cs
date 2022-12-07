using AppModels;
using AutoMapper;
using DomainModels.Entities;

namespace ApiEverest.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CustomerCreateDto, CustomerEntity>();
            CreateMap<CustomerUpdateDto, CustomerEntity>();
            CreateMap<CustomerEntity, CustomerResult>();
        }
    }
}
