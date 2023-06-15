using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.CategoryServiceSpec
{
    public abstract class UsingCategoryServiceSpec : SpecFor<CategoryService>
    {
        protected ICategoryRepository _categoryRepository;

        public override void Context()
        {
            _categoryRepository = Substitute.For<ICategoryRepository>();
            subject = new CategoryService(_categoryRepository);

        }

    }
}