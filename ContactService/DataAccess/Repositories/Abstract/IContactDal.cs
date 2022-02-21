using ContactService.Entities.Concrete;

namespace ContactService.DataAccess.Repositories.Abstract
{
    public interface IContactDal : IBaseRepository<Contact, string>
    {

    }
}
