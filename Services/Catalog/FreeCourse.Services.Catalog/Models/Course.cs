using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FreeCourse.Services.Catalog.Models
{
    public class Course
    {
        [BsonId] //mongodb tarafından gercekten bir id olarak algılanması icin
        [BsonRepresentation(BsonType.ObjectId)]//string olarak verilen Id'yi object'ye cevirir.
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
       
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        public Feature Feature { get; set; }//Feature ile Course table2ları bire-bir iliskili oldugunu bu sekilde belitiyoruz
        
        [BsonRepresentation(BsonType.ObjectId)]//string olarak verilen Id'yi object'ye cevirir.
        public string CategoryId { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }//Productları donerken kategoryleride donmek icin kullanılır

    }
}
