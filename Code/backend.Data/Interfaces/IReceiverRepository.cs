using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface IReceiverRepository : IGetAll<Receiver>,IGet<Receiver,string>, ISave<Receiver>, IUpdate<Receiver, string>, IDelete<string>
    {
    }
}
