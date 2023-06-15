using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class Sender
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public int senderNumber  { get; set; }
        public int userId  { get; set; }
        
    }

}