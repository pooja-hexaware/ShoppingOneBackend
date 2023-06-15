using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
           this._OrderRepository = OrderRepository;
        }
        public IEnumerable<Order> GetAll()
        {
            return _OrderRepository.GetAll();
        }

        public Order Get(string id)
        {
            return _OrderRepository.Get(id);
        }

        public Order Save(Order order)
        {
            _OrderRepository.Save(order);
            return order;
        }

        public Order Update(string id, Order order)
        {
            return _OrderRepository.Update(id, order);
        }

        public bool Delete(string id)
        {
            return _OrderRepository.Delete(id);
        }

    }
}
