using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface IOrderItemService
    {      
        IEnumerable<OrderItem> GetAll();
        OrderItem Get(string id);
        OrderItem Save(OrderItem orderitem);
        OrderItem Update(string id, OrderItem orderitem);
        bool Delete(string id);

    }
}
