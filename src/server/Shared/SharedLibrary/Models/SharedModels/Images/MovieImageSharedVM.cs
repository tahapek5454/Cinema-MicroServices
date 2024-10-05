using MongoDB.Bson.Serialization.Attributes;

namespace SharedLibrary.Models.SharedModels.Images
{
    public class MovieImageSharedVM
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonElement(Order = 1)]
        public int Id { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement(Order = 2)]
        public string FileName { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement(Order = 3)]
        public string Path { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement(Order = 4)]
        public string Storage { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonElement(Order = 5)]
        public int MovieId { get; set; }
    }
}
