using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public int postNumber  { get; set; }
        public string title  { get; set; }
        public string content  { get; set; }
        
    }

}