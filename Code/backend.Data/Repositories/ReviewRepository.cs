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
    public class ReviewRepository : IReviewRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "Review";

        public ReviewRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Review> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Review>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Review Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Review>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Review entity)
        {
            _gateway.GetMongoDB().GetCollection<Review>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Review Update(string id, Review entity)
        {
            var update = Builders<Review>.Update
                .Set(e => e.reviewNumber, entity.reviewNumber )
                .Set(e => e.rating, entity.rating )
                .Set(e => e.content, entity.content );

            var result = _gateway.GetMongoDB().GetCollection<Review>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Review>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
