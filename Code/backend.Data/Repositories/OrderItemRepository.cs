using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "OrderItem";

        public OrderItemRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<OrderItem> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<OrderItem>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public OrderItem Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<OrderItem>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(OrderItem entity)
        {
            _gateway.GetMongoDB().GetCollection<OrderItem>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public OrderItem Update(string id, OrderItem entity)
        {
            var update = Builders<OrderItem>.Update
                .Set(e => e.productNumber, entity.productNumber )
                .Set(e => e.quantity, entity.quantity )
                .Set(e => e.price, entity.price );

            var result = _gateway.GetMongoDB().GetCollection<OrderItem>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<OrderItem>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
