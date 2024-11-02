using MongoDB.Bson.Serialization.Attributes;
using SharedLibrary.Attributes;
using SharedLibrary.Models.Entities;

namespace SharedLibrary.Models.SharedModels.Comments
{
    [CollectionInfo("movie_comment_shared_model")]

    public class MovieCommentSharedVM: SharedBaseEntity
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement(Order = 1)]
        public string Comment { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement(Order = 2)]
        public DateTime CreatedDate { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement(Order = 3)]
        public DateTime? UpdatedDate { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonElement(Order = 4)]
        public int MovieId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonElement(Order = 5)]
        public int UserId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement(Order = 6)]
        public string UserName { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonElement(Order = 7)]
        public int LikeCount { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonElement(Order = 8)]
        public int? ParenId { get; set; }
    }
}
