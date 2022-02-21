using ReportService.Entities.Abstract;

namespace ReportService.Entities.Concrete
{
    public class Report:BaseEntity
    {
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneCount { get; set; }
    }
}
