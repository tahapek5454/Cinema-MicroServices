using MongoDB.Bson.Serialization.Attributes;
using SharedLibrary.Attributes;
using SharedLibrary.Models.Entities;

namespace SharedLibrary.Models.SharedModels.Categories
{
    [CollectionInfo("category_shared_model")]

    public class CategorySharedVM: SharedBaseEntity
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement(Order = 1)]
        public string Name { get; set; }
    }
}
