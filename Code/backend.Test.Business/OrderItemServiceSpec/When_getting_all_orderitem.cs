using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.OrderItemServiceSpec
{
    public class When_getting_all_orderitem : UsingOrderItemServiceSpec
    {
        private IEnumerable<OrderItem> _result;

        private IEnumerable<OrderItem> _all_orderitem;
        private OrderItem _orderitem;

        public override void Context()
        {
            base.Context();

            _orderitem = new OrderItem{
                productNumber = "productNumber",
                quantity = 26,
                price = 52.8
            };

            _all_orderitem = new List<OrderItem> { _orderitem};
            _orderitemRepository.GetAll().Returns(_all_orderitem);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _orderitemRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<OrderItem>>();

            List<OrderItem> resultList = _result as List<OrderItem>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_orderitem);
        }
    }
}