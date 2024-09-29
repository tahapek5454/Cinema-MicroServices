using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SharedLibrary.Models.Entities
{
    public class SharedBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        [BsonElement(Order = 0)]
        public int Id { get; set; }
    }
}
