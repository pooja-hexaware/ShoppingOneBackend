using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.OrderItemControllerSpec
{
    public class When_getting_all_orderitem : UsingOrderItemControllerSpec
    {
        private ActionResult<IEnumerable<OrderItemDto>> _result;

        private IEnumerable<OrderItem> _all_orderitem;
        private OrderItem _orderitem;

        private IEnumerable<OrderItemDto>  _all_orderitemDto;
        private OrderItemDto _orderitemDto;
    

        public override void Context()
        {
            base.Context();

            _orderitem = new OrderItem{
                productNumber = "productNumber",
                quantity = 30,
                price = 13.74
            };

            _orderitemDto = new OrderItemDto{
                    productNumber = "productNumber",
                    quantity = 59,
                    price = 38.33
                };

            _all_orderitem = new List<OrderItem> { _orderitem};
            _orderitemService.GetAll().Returns(_all_orderitem);
            _all_orderitemDto  = new List<OrderItemDto> {_orderitemDto};
            _mapper.Map<IEnumerable<OrderItemDto>>(_all_orderitem).Returns( _all_orderitemDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _orderitemService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<OrderItemDto>>();

            List<OrderItemDto> resultList = resultListObject as List<OrderItemDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_orderitemDto);
        }
    }
}