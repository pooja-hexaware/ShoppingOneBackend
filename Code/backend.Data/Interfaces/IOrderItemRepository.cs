using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface IOrderItemRepository : IGetAll<OrderItem>,IGet<OrderItem,string>, ISave<OrderItem>, IUpdate<OrderItem, string>, IDelete<string>
    {
    }
}
