using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactService.Entities.Base
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string? Id { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
