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
    public class ProductRepository : IProductRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "Product";

        public ProductRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Product> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Product Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Product entity)
        {
            _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Product Update(string id, Product entity)
        {
            var update = Builders<Product>.Update
                .Set(e => e.productNumber, entity.productNumber )
                .Set(e => e.productName, entity.productName )
                .Set(e => e.description, entity.description )
                .Set(e => e.price, entity.price );

            var result = _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
