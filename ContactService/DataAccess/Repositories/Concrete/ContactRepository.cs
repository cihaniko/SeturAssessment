using ContactService.DataAccess.Core;
using ContactService.DataAccess.Repositories.Abstract;
using ContactService.Entities.Concrete;
using Microsoft.Extensions.Options;

namespace ContactService.DataAccess.Repositories.Concrete
{

    public class ContactRepository : MongoDbRepositoryBase<Contact>, IContactDal
    {
        public ContactRepository(IOptions<DatabaseSettings> options) : base(options)
        {
        }
    }
}
