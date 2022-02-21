using ReportService.Entities.Abstract;

namespace ReportService.Entities.Concrete
{
    public class ReportStatus:BaseEntity
    {
        public string Status { get; set; }
        public string? ReportDetail { get; set; }
    }
    public enum ReportStatusEnum
    {
        Hazirlaniyor=1,
        Tamamlandi=2,
    }
}
