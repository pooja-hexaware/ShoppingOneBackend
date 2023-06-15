using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class OrderItemDto { 
     public string Id { get; set; }
        public string productNumber { get; set; } 
        public int quantity { get; set; } 
        public double price { get; set; } 
} 
}
