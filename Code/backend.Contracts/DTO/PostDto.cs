using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class PostDto { 
     public string Id { get; set; }
        public int postNumber { get; set; } 
        public string title { get; set; } 
        public string content { get; set; } 
} 
}
