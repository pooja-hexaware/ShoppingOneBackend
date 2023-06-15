using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public int userId  { get; set; }
        public string username  { get; set; }
        public double email  { get; set; }
        public int password  { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime doj  { get; set; }
        
    }

}