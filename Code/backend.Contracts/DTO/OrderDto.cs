using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class OrderDto { 
     public string Id { get; set; }
        public int orderNumber { get; set; } 
        public double totalAmt { get; set; } 
        public DateTime orderDate { get; set; } 
} 
}
