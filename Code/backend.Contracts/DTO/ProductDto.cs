using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class ProductDto { 
     public string Id { get; set; }
        public int productNumber { get; set; } 
        public string productName { get; set; } 
        public bool description { get; set; } 
        public double price { get; set; } 
} 
}
