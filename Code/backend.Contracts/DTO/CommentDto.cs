using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class CommentDto { 
     public string Id { get; set; }
        public int commentNumber { get; set; } 
        public string content { get; set; } 
} 
}
