using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.ProductControllerSpec
{
    public class When_getting_all_product : UsingProductControllerSpec
    {
        private ActionResult<IEnumerable<ProductDto>> _result;

        private IEnumerable<Product> _all_product;
        private Product _product;

        private IEnumerable<ProductDto>  _all_productDto;
        private ProductDto _productDto;
    

        public override void Context()
        {
            base.Context();

            _product = new Product{
                productNumber = 66,
                productName = "productName",
                description = false,
                price = 32.32
            };

            _productDto = new ProductDto{
                    productNumber = 2,
                    productName = "productName",
                    description = true,
                    price = 37.35
                };

            _all_product = new List<Product> { _product};
            _productService.GetAll().Returns(_all_product);
            _all_productDto  = new List<ProductDto> {_productDto};
            _mapper.Map<IEnumerable<ProductDto>>(_all_product).Returns( _all_productDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _productService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<ProductDto>>();

            List<ProductDto> resultList = resultListObject as List<ProductDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_productDto);
        }
    }
}