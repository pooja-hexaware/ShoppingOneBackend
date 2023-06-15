using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace backend.Contracts.DTO {
   public class UserDto { 
     public string Id { get; set; }
        public int userId { get; set; } 
        public string username { get; set; } 
        public double email { get; set; } 
        public int password { get; set; } 
        public DateTime doj { get; set; } 
} 
}
