using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public string messageNumber  { get; set; }
        public string senderNumber  { get; set; }
        public string receiverNumber  { get; set; }
        public string content  { get; set; }
        
    }

}