using AppModels;
using AutoMapper;
using DomainModels.Entities;


namespace ApiEverest.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CustomerEntity, CustomerCreateDto>();
            CreateMap<CustomerEntity, CustomerUpdateDto>();
            CreateMap<CustomerResult, CustomerEntity>();

        }

    }
}
