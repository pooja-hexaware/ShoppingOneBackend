using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;


namespace backend.Test.Business.OrderServiceSpec
{
    public class When_updating_order : UsingOrderServiceSpec
    {
        private Order _result;
        private Order _order;

        public override void Context()
        {
            base.Context();

            _order = new Order
            {
                orderNumber = 33,
                totalAmt = 49.91,
                orderDate = new DateTime()
            };

            _orderRepository.Update(_order.Id, _order).Returns(_order);
            
        }
        public override void Because()
        {
            _result = subject.Update(_order.Id, _order);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _orderRepository.Received(1).Update(_order.Id, _order);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Order>();

            _result.ShouldBe(_order);
        }
    }
}