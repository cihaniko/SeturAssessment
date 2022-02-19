using ContactService.Entities.Concrete;
using ContactService.Utilities.Result;

namespace ContactService.Business.ContactDetailsService
{
    public interface IContactDetailsManager
    {
        Task<IResultModel> Add(ContactDetails contact);
        Task<IResultModel> Delete(string id);
        Task<IResultModel> Get(string id);
        IResultModel GetAll();
    }
}