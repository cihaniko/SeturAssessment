namespace ReportService.Entities.Abstract
{
    public interface IBaseEntity
    {


    }
    public interface IBaseEntity<out TKey> : IBaseEntity where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }
        DateTime CreatedAt { get; set; }
    }
}