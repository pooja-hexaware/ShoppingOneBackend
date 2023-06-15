using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.ProductControllerSpec
{
    public abstract class UsingProductControllerSpec : SpecFor<ProductController>
    {
        protected IProductService _productService;
        protected IMapper _mapper;

        public override void Context()
        {
            _productService = Substitute.For<IProductService>();
            _mapper = Substitute.For<IMapper>();
            subject = new ProductController(_productService,_mapper);

        }

    }
}
