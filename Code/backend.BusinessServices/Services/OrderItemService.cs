using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class OrderItemService : IOrderItemService
    {
        readonly IOrderItemRepository _OrderItemRepository;

        public OrderItemService(IOrderItemRepository OrderItemRepository)
        {
           this._OrderItemRepository = OrderItemRepository;
        }
        public IEnumerable<OrderItem> GetAll()
        {
            return _OrderItemRepository.GetAll();
        }

        public OrderItem Get(string id)
        {
            return _OrderItemRepository.Get(id);
        }

        public OrderItem Save(OrderItem orderitem)
        {
            _OrderItemRepository.Save(orderitem);
            return orderitem;
        }

        public OrderItem Update(string id, OrderItem orderitem)
        {
            return _OrderItemRepository.Update(id, orderitem);
        }

        public bool Delete(string id)
        {
            return _OrderItemRepository.Delete(id);
        }

    }
}
