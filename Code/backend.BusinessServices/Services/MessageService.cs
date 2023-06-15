using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class MessageService : IMessageService
    {
        readonly IMessageRepository _MessageRepository;

        public MessageService(IMessageRepository MessageRepository)
        {
           this._MessageRepository = MessageRepository;
        }
        public IEnumerable<Message> GetAll()
        {
            return _MessageRepository.GetAll();
        }

        public Message Get(string id)
        {
            return _MessageRepository.Get(id);
        }

        public Message Save(Message message)
        {
            _MessageRepository.Save(message);
            return message;
        }

        public Message Update(string id, Message message)
        {
            return _MessageRepository.Update(id, message);
        }

        public bool Delete(string id)
        {
            return _MessageRepository.Delete(id);
        }

    }
}
