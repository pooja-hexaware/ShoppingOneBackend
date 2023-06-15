using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.OrderControllerSpec
{
    public class When_getting_all_order : UsingOrderControllerSpec
    {
        private ActionResult<IEnumerable<OrderDto>> _result;

        private IEnumerable<Order> _all_order;
        private Order _order;

        private IEnumerable<OrderDto>  _all_orderDto;
        private OrderDto _orderDto;
    

        public override void Context()
        {
            base.Context();

            _order = new Order{
                orderNumber = 15,
                totalAmt = 13.07,
                orderDate = new DateTime()
            };

            _orderDto = new OrderDto{
                    orderNumber = 82,
                    totalAmt = 3.03,
                    orderDate = new DateTime()
                };

            _all_order = new List<Order> { _order};
            _orderService.GetAll().Returns(_all_order);
            _all_orderDto  = new List<OrderDto> {_orderDto};
            _mapper.Map<IEnumerable<OrderDto>>(_all_order).Returns( _all_orderDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _orderService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<OrderDto>>();

            List<OrderDto> resultList = resultListObject as List<OrderDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_orderDto);
        }
    }
}