using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface IMessageService
    {      
        IEnumerable<Message> GetAll();
        Message Get(string id);
        Message Save(Message message);
        Message Update(string id, Message message);
        bool Delete(string id);

    }
}
