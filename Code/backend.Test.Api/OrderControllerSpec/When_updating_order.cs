using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;
using backend.BusinessServices.Services;

namespace backend.Test.Api.OrderControllerSpec
{
    public class When_updating_order : UsingOrderControllerSpec
    {
        private ActionResult<OrderDto > _result;
        private Order _order;
        private OrderDto _orderDto;

        public override void Context()
        {
            base.Context();

            _order = new Order
            {
                orderNumber = 42,
                totalAmt = 5.22,
                orderDate = new DateTime()
            };

            _orderDto = new OrderDto{
                    orderNumber = 67,
                    totalAmt = 43.04,
                    orderDate = new DateTime()
            };

            _orderService.Update(_order.Id, _order).Returns(_order);
            _mapper.Map<OrderDto>(_order).Returns(_orderDto);
            
        }
        public override void Because()
        {
            _result = subject.Update(_order.Id, _order);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _orderService.Received(1).Update(_order.Id, _order);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<OrderDto>();

            var resultList = resultListObject as OrderDto;

            resultList.ShouldBe(_orderDto);
        }
    }
}