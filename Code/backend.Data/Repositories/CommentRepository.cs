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
    public class CommentRepository : ICommentRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "Comment";

        public CommentRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Comment> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Comment>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Comment Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Comment>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Comment entity)
        {
            _gateway.GetMongoDB().GetCollection<Comment>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Comment Update(string id, Comment entity)
        {
            var update = Builders<Comment>.Update
                .Set(e => e.commentNumber, entity.commentNumber )
                .Set(e => e.content, entity.content );

            var result = _gateway.GetMongoDB().GetCollection<Comment>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Comment>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
