using ContactService.DataAccess.Repositories.Abstract;
using ContactService.Entities.Concrete;
using ContactService.Utilities.Constants;
using ContactService.Utilities.Result;

namespace ContactService.Business.ContactDetailsService
{
    public class ContactDetailsManager : IContactDetailsManager
    {
        private readonly IContactDetailsDal _contactDetailDal;

        public ContactDetailsManager(IContactDetailsDal contactDetailDal)
        {
            this._contactDetailDal = contactDetailDal;
        }

        public async Task<IResultModel> Add(ContactDetails contact)
        {
            await _contactDetailDal.AddAsync(contact);

            return new ResultModel() { IsSuccess = true, Message = ResultMessages.SuccessMessage };
        }
        public async Task<IResultModel> Delete(string id)
        {
            await _contactDetailDal.DeleteAsync(id);

            return new ResultModel() { IsSuccess = true, Message = ResultMessages.SuccessMessage };
        }
        public IResultModel GetAll()
        {
            IQueryable result = _contactDetailDal.Get();

            return new ResultModel<IQueryable>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = result };
        }
        public async Task<IResultModel> Get(string id)
        {
            ContactDetails result = await _contactDetailDal.GetByIdAsync(id);

            if (result == null)
                return new ResultModel() { IsSuccess = false, Message = ResultMessages.RecordNotFound };

            return new ResultModel<ContactDetails>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = result };
        }
        public IResultModel<IQueryable<ContactDetails>> GetListByContactId(string id)
        {
            var result = _contactDetailDal.Get(x => x.ContactId == id);

            return new ResultModel<IQueryable<ContactDetails>>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = result };
        }

    }
}
