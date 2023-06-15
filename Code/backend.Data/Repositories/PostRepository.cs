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
    public class PostRepository : IPostRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "Post";

        public PostRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Post> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Post>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Post Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Post>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Post entity)
        {
            _gateway.GetMongoDB().GetCollection<Post>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Post Update(string id, Post entity)
        {
            var update = Builders<Post>.Update
                .Set(e => e.postNumber, entity.postNumber )
                .Set(e => e.title, entity.title )
                .Set(e => e.content, entity.content );

            var result = _gateway.GetMongoDB().GetCollection<Post>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Post>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
