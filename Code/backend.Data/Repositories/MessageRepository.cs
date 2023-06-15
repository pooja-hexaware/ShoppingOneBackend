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
    public class MessageRepository : IMessageRepository
    {
        private readonly IGateway _gateway;
        private readonly string _collectionName = "Message";

        public MessageRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Message> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Message>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Message Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Message>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Message entity)
        {
            _gateway.GetMongoDB().GetCollection<Message>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Message Update(string id, Message entity)
        {
            var update = Builders<Message>.Update
                .Set(e => e.messageNumber, entity.messageNumber )
                .Set(e => e.senderNumber, entity.senderNumber )
                .Set(e => e.receiverNumber, entity.receiverNumber )
                .Set(e => e.content, entity.content );

            var result = _gateway.GetMongoDB().GetCollection<Message>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Message>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
