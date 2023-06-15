using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public int orderNumber  { get; set; }
        public double totalAmt  { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime orderDate  { get; set; }
        
    }

}