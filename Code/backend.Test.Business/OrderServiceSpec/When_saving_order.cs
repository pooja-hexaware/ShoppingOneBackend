using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.OrderServiceSpec
{
    public class When_saving_order : UsingOrderServiceSpec
    {
        private Order _result;

        private Order _order;

        public override void Context()
        {
            base.Context();

            _order = new Order
            {
                orderNumber = 5,
                totalAmt = 54.13,
                orderDate = new DateTime()
            };

            _orderRepository.Save(_order).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_order);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _orderRepository.Received(1).Save(_order);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Order>();

            _result.ShouldBe(_order);
        }
    }
}