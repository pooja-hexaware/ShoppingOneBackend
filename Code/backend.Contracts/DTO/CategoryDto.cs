using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class CategoryDto { 
     public string Id { get; set; }
        public int categoryNumber { get; set; } 
        public string categoryName { get; set; } 
        public bool description { get; set; } 
} 
}
