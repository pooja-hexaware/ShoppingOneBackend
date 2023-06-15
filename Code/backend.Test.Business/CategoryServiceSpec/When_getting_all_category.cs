using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.CategoryServiceSpec
{
    public class When_getting_all_category : UsingCategoryServiceSpec
    {
        private IEnumerable<Category> _result;

        private IEnumerable<Category> _all_category;
        private Category _category;

        public override void Context()
        {
            base.Context();

            _category = new Category{
                categoryNumber = 86,
                categoryName = "categoryName",
                description = true
            };

            _all_category = new List<Category> { _category};
            _categoryRepository.GetAll().Returns(_all_category);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _categoryRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Category>>();

            List<Category> resultList = _result as List<Category>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_category);
        }
    }
}