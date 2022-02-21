using ContactService.DataAccess.Repositories.Abstract;
using ContactService.Entities.Concrete;
using ContactService.Utilities.Constants;
using ContactService.Utilities.Result;

namespace ContactService.Business.ContactService
{
    public class ContactManager : IContactManager
    {
        private readonly IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public async Task<IResultModel> Add(Contact contact)
        {
            await contactDal.AddAsync(contact);

            return new ResultModel() { IsSuccess = true, Message = ResultMessages.SuccessMessage };
        }
        public async Task<IResultModel> Delete(string id)
        {
            await contactDal.DeleteAsync(id);

            return new ResultModel() { IsSuccess = true, Message = ResultMessages.SuccessMessage };
        }
        public IResultModel GetAll()
        {
            IQueryable<Contact> result = contactDal.Get();

            return new ResultModel<IQueryable<Contact>>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data=result };
        }
        public async Task<IResultModel<Contact>> Get(string id)
        {
            Contact result = await contactDal.GetByIdAsync(id);

            return new ResultModel<Contact>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data=result};
        }
        public async Task<ResultModel<bool>> IsExist(string id)
        {
            var result = await contactDal.IsExistAsync(id);
            
            return new ResultModel<bool>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = result };
        }
    }
}
