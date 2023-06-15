using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class SenderDto { 
     public string Id { get; set; }
        public int senderNumber { get; set; } 
        public int userId { get; set; } 
} 
}
