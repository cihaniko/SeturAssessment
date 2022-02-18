using ReportService.DataAccess.Core.Interfaces;

namespace ReportService.DataAccess.Core
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
