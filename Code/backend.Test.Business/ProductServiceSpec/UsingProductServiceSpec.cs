using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.ProductServiceSpec
{
    public abstract class UsingProductServiceSpec : SpecFor<ProductService>
    {
        protected IProductRepository _productRepository;

        public override void Context()
        {
            _productRepository = Substitute.For<IProductRepository>();
            subject = new ProductService(_productRepository);

        }

    }
}