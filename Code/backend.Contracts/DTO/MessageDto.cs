using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class MessageDto { 
     public string Id { get; set; }
        public string messageNumber { get; set; } 
        public string senderNumber { get; set; } 
        public string receiverNumber { get; set; } 
        public string content { get; set; } 
} 
}
