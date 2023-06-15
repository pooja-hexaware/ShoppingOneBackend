using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;


namespace backend.Test.Business.ReviewServiceSpec
{
    public class When_updating_review : UsingReviewServiceSpec
    {
        private Review _result;
        private Review _review;

        public override void Context()
        {
            base.Context();

            _review = new Review
            {
                reviewNumber = 31,
                rating = 99,
                content = "content"
            };

            _reviewRepository.Update(_review.Id, _review).Returns(_review);
            
        }
        public override void Because()
        {
            _result = subject.Update(_review.Id, _review);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _reviewRepository.Received(1).Update(_review.Id, _review);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Review>();

            _result.ShouldBe(_review);
        }
    }
}