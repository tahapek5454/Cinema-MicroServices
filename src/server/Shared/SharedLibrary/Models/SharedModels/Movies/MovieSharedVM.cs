using MongoDB.Bson.Serialization.Attributes;
using SharedLibrary.Attributes;
using SharedLibrary.Models.Entities;
using SharedLibrary.Models.SharedModels.Categories;
using SharedLibrary.Models.SharedModels.Images;

namespace SharedLibrary.Models.SharedModels.Movies
{
    [CollectionInfo("movie_shared_model")]
    public class MovieSharedVM : SharedBaseEntity
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement(Order = 1)]
        public string Name { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement(Order = 2)]
        public string Description { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
        [BsonElement(Order = 3)]
        public double Point { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
        [BsonElement(Order = 4)]
        public double Time { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement(Order = 5)]
        public DateTime CreatedDate { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement(Order = 6)]
        public DateTime? UpdatedDate { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonElement(Order = 7)]
        public int CategoryId { get; set; }


        [BsonElement(Order = 8)]
        public CategorySharedVM? Category { get; set; }


        [BsonElement(Order = 9)]
        public List<MovieImageSharedVM>? MovieImages { get; set; }

    }
}
