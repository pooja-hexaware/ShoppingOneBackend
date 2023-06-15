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
    public class SenderRepository : ISenderRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "Sender";

        public SenderRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Sender> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Sender>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Sender Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Sender>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Sender entity)
        {
            _gateway.GetMongoDB().GetCollection<Sender>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Sender Update(string id, Sender entity)
        {
            var update = Builders<Sender>.Update
                .Set(e => e.senderNumber, entity.senderNumber )
                .Set(e => e.userId, entity.userId );

            var result = _gateway.GetMongoDB().GetCollection<Sender>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Sender>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
