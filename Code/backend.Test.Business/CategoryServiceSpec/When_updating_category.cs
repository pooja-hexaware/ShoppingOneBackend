using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;


namespace backend.Test.Business.CategoryServiceSpec
{
    public class When_updating_category : UsingCategoryServiceSpec
    {
        private Category _result;
        private Category _category;

        public override void Context()
        {
            base.Context();

            _category = new Category
            {
                categoryNumber = 81,
                categoryName = "categoryName",
                description = true
            };

            _categoryRepository.Update(_category.Id, _category).Returns(_category);
            
        }
        public override void Because()
        {
            _result = subject.Update(_category.Id, _category);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _categoryRepository.Received(1).Update(_category.Id, _category);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Category>();

            _result.ShouldBe(_category);
        }
    }
}