using ReportService.Entities.Abstract;

namespace ReportService.Entities.Dto
{
    public class ContactDetails: BaseEntity
    {
        public string ContactId { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

    }
}
