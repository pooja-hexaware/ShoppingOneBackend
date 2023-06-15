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

namespace backend.Test.Api.OrderItemControllerSpec
{
    public class When_updating_orderitem : UsingOrderItemControllerSpec
    {
        private ActionResult<OrderItemDto > _result;
        private OrderItem _orderitem;
        private OrderItemDto _orderitemDto;

        public override void Context()
        {
            base.Context();

            _orderitem = new OrderItem
            {
                productNumber = "productNumber",
                quantity = 53,
                price = 55.78
            };

            _orderitemDto = new OrderItemDto{
                    productNumber = "productNumber",
                    quantity = 41,
                    price = 30.02
            };

            _orderitemService.Update(_orderitem.Id, _orderitem).Returns(_orderitem);
            _mapper.Map<OrderItemDto>(_orderitem).Returns(_orderitemDto);
            
        }
        public override void Because()
        {
            _result = subject.Update(_orderitem.Id, _orderitem);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _orderitemService.Received(1).Update(_orderitem.Id, _orderitem);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<OrderItemDto>();

            var resultList = resultListObject as OrderItemDto;

            resultList.ShouldBe(_orderitemDto);
        }
    }
}