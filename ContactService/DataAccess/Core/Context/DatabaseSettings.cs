using ContactService.DataAccess.Core.Interfaces;

namespace ContactService.DataAccess.Core
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
