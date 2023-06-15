using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;


namespace backend.Test.Business.OrderItemServiceSpec
{
    public class When_updating_orderitem : UsingOrderItemServiceSpec
    {
        private OrderItem _result;
        private OrderItem _orderitem;

        public override void Context()
        {
            base.Context();

            _orderitem = new OrderItem
            {
                productNumber = "productNumber",
                quantity = 20,
                price = 64.57
            };

            _orderitemRepository.Update(_orderitem.Id, _orderitem).Returns(_orderitem);
            
        }
        public override void Because()
        {
            _result = subject.Update(_orderitem.Id, _orderitem);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _orderitemRepository.Received(1).Update(_orderitem.Id, _orderitem);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<OrderItem>();

            _result.ShouldBe(_orderitem);
        }
    }
}