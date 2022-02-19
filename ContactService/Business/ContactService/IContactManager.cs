using ContactService.Entities.Concrete;
using ContactService.Utilities.Result;

namespace ContactService.Business.ContactService
{
    public interface IContactManager
    {
        Task<IResultModel> Add(Contact contact);
        Task<IResultModel> Delete(string id);
        IResultModel GetAll();
        Task<IResultModel> Get(string id);
        Task<ResultModel<bool>> IsExist(string id);
    }
}