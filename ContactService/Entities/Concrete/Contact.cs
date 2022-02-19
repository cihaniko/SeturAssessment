
using ContactService.Entities.Abstract;

namespace ContactService.Entities.Concrete
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
