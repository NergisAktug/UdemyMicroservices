using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Services.Catalog.Models
{
    public class Category
    {
        [BsonId] //mongodb tarafından gercekten bir id olarak algılanması icin
        [BsonRepresentation(BsonType.ObjectId)]//string olarak verilen Id'yi object'ye cevirir.
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
