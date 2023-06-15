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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "Category";

        public CategoryRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Category> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Category>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Category Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Category>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Category entity)
        {
            _gateway.GetMongoDB().GetCollection<Category>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Category Update(string id, Category entity)
        {
            var update = Builders<Category>.Update
                .Set(e => e.categoryNumber, entity.categoryNumber )
                .Set(e => e.categoryName, entity.categoryName )
                .Set(e => e.description, entity.description );

            var result = _gateway.GetMongoDB().GetCollection<Category>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Category>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
