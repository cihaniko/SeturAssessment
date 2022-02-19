using ContactService.DataAccess.Repositories.Abstract;
using ContactService.Entities.Concrete;
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

            return new ResultModel() { IsSuccess = true, Message = "asd" };
        }
        public async Task<IResultModel> Delete(string id)
        {
            await _contactDetailDal.DeleteAsync(id);

            return new ResultModel() { IsSuccess = true, Message = "asd" };
        }
        public IResultModel GetAll()
        {
            IQueryable result = _contactDetailDal.Get();

            return new ResultModel<IQueryable>() { IsSuccess = true, Message = "asd", Data = result };
        }
        public async Task<IResultModel> Get(string id)
        {
            ContactDetails result = await _contactDetailDal.GetByIdAsync(id);

            return new ResultModel<ContactDetails>() { IsSuccess = true, Message = "asd", Data = result };
        }
    }
}
