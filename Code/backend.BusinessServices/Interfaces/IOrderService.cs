using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface IOrderService
    {      
        IEnumerable<Order> GetAll();
        Order Get(string id);
        Order Save(Order order);
        Order Update(string id, Order order);
        bool Delete(string id);

    }
}
