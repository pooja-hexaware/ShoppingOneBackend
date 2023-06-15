using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface IOrderRepository : IGetAll<Order>,IGet<Order,string>, ISave<Order>, IUpdate<Order, string>, IDelete<string>
    {
    }
}
