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

namespace backend.Test.Api.CategoryControllerSpec
{
    public class When_updating_category : UsingCategoryControllerSpec
    {
        private ActionResult<CategoryDto > _result;
        private Category _category;
        private CategoryDto _categoryDto;

        public override void Context()
        {
            base.Context();

            _category = new Category
            {
                categoryNumber = 8,
                categoryName = "categoryName",
                description = false
            };

            _categoryDto = new CategoryDto{
                    categoryNumber = 40,
                    categoryName = "categoryName",
                    description = true
            };

            _categoryService.Update(_category.Id, _category).Returns(_category);
            _mapper.Map<CategoryDto>(_category).Returns(_categoryDto);
            
        }
        public override void Because()
        {
            _result = subject.Update(_category.Id, _category);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _categoryService.Received(1).Update(_category.Id, _category);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<CategoryDto>();

            var resultList = resultListObject as CategoryDto;

            resultList.ShouldBe(_categoryDto);
        }
    }
}