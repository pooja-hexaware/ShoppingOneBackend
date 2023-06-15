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
    public class ReceiverRepository : IReceiverRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "Receiver";

        public ReceiverRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Receiver> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Receiver>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Receiver Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Receiver>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Receiver entity)
        {
            _gateway.GetMongoDB().GetCollection<Receiver>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Receiver Update(string id, Receiver entity)
        {
            var update = Builders<Receiver>.Update
                .Set(e => e.receiverNumber, entity.receiverNumber )
                .Set(e => e.userId, entity.userId );

            var result = _gateway.GetMongoDB().GetCollection<Receiver>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Receiver>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
