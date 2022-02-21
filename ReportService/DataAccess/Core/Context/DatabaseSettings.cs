using ReportService.DataAccess.Core.Interfaces;

namespace ReportService.DataAccess.Core
{
    public class DatabaseSettings 
    {
        //public string ConnectionString { get; set; } = null!;
        //public string DatabaseName { get; set; } = null!;

        public string ConnectionString;
        public string DatabaseName;

        //Configuration için kullanılacak
        #region Const Values

        public const string ConnectionStringValue = nameof(ConnectionString);
        public const string DatabaseValue = nameof(DatabaseName);

        #endregion
    }
}
