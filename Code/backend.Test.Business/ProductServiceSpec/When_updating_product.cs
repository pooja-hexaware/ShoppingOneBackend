using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;


namespace backend.Test.Business.ProductServiceSpec
{
    public class When_updating_product : UsingProductServiceSpec
    {
        private Product _result;
        private Product _product;

        public override void Context()
        {
            base.Context();

            _product = new Product
            {
                productNumber = 67,
                productName = "productName",
                description = false,
                price = 47.37
            };

            _productRepository.Update(_product.Id, _product).Returns(_product);
            
        }
        public override void Because()
        {
            _result = subject.Update(_product.Id, _product);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _productRepository.Received(1).Update(_product.Id, _product);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Product>();

            _result.ShouldBe(_product);
        }
    }
}