namespace ContactService.DataAccess.Core.Interfaces
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}