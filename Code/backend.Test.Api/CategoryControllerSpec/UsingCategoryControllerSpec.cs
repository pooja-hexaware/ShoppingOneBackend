using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.CategoryControllerSpec
{
    public abstract class UsingCategoryControllerSpec : SpecFor<CategoryController>
    {
        protected ICategoryService _categoryService;
        protected IMapper _mapper;

        public override void Context()
        {
            _categoryService = Substitute.For<ICategoryService>();
            _mapper = Substitute.For<IMapper>();
            subject = new CategoryController(_categoryService,_mapper);

        }

    }
}
