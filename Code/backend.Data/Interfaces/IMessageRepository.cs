using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface IMessageRepository : IGetAll<Message>,IGet<Message,string>, ISave<Message>, IUpdate<Message, string>, IDelete<string>
    {
    }
}
