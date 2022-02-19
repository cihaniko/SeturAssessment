using ContactService.DataAccess.Core;
using ContactService.DataAccess.Repositories.Abstract;
using ContactService.Entities.Concrete;
using Microsoft.Extensions.Options;

namespace ContactService.DataAccess.Repositories.Concrete
{
  
    public class ContactDetailsRepository : MongoDbRepositoryBase<ContactDetails>, IContactDetailsDal
    {
        public ContactDetailsRepository(IOptions<DatabaseSettings> options) : base(options)
        {
        }
    }
}
