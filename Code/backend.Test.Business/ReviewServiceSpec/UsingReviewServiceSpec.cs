using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.ReviewServiceSpec
{
    public abstract class UsingReviewServiceSpec : SpecFor<ReviewService>
    {
        protected IReviewRepository _reviewRepository;

        public override void Context()
        {
            _reviewRepository = Substitute.For<IReviewRepository>();
            subject = new ReviewService(_reviewRepository);

        }

    }
}