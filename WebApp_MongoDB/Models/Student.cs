using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp_MongoDB.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Lastname{ get; set; }
        [BsonElement]
        public string Email { get; set; }
        [BsonElement]
        public string User { get; set; }
    }
}