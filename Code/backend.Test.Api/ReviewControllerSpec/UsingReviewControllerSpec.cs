using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.ReviewControllerSpec
{
    public abstract class UsingReviewControllerSpec : SpecFor<ReviewController>
    {
        protected IReviewService _reviewService;
        protected IMapper _mapper;

        public override void Context()
        {
            _reviewService = Substitute.For<IReviewService>();
            _mapper = Substitute.For<IMapper>();
            subject = new ReviewController(_reviewService,_mapper);

        }

    }
}
