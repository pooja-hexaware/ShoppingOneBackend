using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface ISenderRepository : IGetAll<Sender>,IGet<Sender,string>, ISave<Sender>, IUpdate<Sender, string>, IDelete<string>
    {
    }
}
