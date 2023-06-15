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

namespace backend.Test.Api.ProductControllerSpec
{
    public class When_updating_product : UsingProductControllerSpec
    {
        private ActionResult<ProductDto > _result;
        private Product _product;
        private ProductDto _productDto;

        public override void Context()
        {
            base.Context();

            _product = new Product
            {
                productNumber = 98,
                productName = "productName",
                description = false,
                price = 51.92
            };

            _productDto = new ProductDto{
                    productNumber = 34,
                    productName = "productName",
                    description = false,
                    price = 81.96
            };

            _productService.Update(_product.Id, _product).Returns(_product);
            _mapper.Map<ProductDto>(_product).Returns(_productDto);
            
        }
        public override void Because()
        {
            _result = subject.Update(_product.Id, _product);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _productService.Received(1).Update(_product.Id, _product);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<ProductDto>();

            var resultList = resultListObject as ProductDto;

            resultList.ShouldBe(_productDto);
        }
    }
}