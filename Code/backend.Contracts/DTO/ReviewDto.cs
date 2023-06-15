using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class ReviewDto { 
     public string Id { get; set; }
        public int reviewNumber { get; set; } 
        public int rating { get; set; } 
        public string content { get; set; } 
} 
}
