using DomainModels.Entities;

namespace AppServices.Services
{
    public interface ICostumerAppService
    {
        void Create(CustomerEntity model);
        void Update(CustomerEntity model);
        void Delete(long id);
        IEnumerable<CustomerEntity> GetAll();
        CustomerEntity GetById(long id);
    }
}
