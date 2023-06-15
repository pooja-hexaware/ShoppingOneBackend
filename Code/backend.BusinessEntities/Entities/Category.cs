using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public int categoryNumber  { get; set; }
        public string categoryName  { get; set; }
        public bool description  { get; set; }
        
    }

}