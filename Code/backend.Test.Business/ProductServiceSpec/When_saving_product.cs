using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.ProductServiceSpec
{
    public class When_saving_product : UsingProductServiceSpec
    {
        private Product _result;

        private Product _product;

        public override void Context()
        {
            base.Context();

            _product = new Product
            {
                productNumber = 6,
                productName = "productName",
                description = false,
                price = 71.41
            };

            _productRepository.Save(_product).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_product);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _productRepository.Received(1).Save(_product);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Product>();

            _result.ShouldBe(_product);
        }
    }
}