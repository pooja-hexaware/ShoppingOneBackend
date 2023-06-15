using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class ReceiverDto { 
     public string Id { get; set; }
        public int receiverNumber { get; set; } 
        public int userId { get; set; } 
} 
}
