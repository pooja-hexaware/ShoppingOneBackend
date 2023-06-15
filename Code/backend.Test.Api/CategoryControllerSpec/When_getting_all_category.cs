using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.CategoryControllerSpec
{
    public class When_getting_all_category : UsingCategoryControllerSpec
    {
        private ActionResult<IEnumerable<CategoryDto>> _result;

        private IEnumerable<Category> _all_category;
        private Category _category;

        private IEnumerable<CategoryDto>  _all_categoryDto;
        private CategoryDto _categoryDto;
    

        public override void Context()
        {
            base.Context();

            _category = new Category{
                categoryNumber = 8,
                categoryName = "categoryName",
                description = true
            };

            _categoryDto = new CategoryDto{
                    categoryNumber = 30,
                    categoryName = "categoryName",
                    description = false
                };

            _all_category = new List<Category> { _category};
            _categoryService.GetAll().Returns(_all_category);
            _all_categoryDto  = new List<CategoryDto> {_categoryDto};
            _mapper.Map<IEnumerable<CategoryDto>>(_all_category).Returns( _all_categoryDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _categoryService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<CategoryDto>>();

            List<CategoryDto> resultList = resultListObject as List<CategoryDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_categoryDto);
        }
    }
}