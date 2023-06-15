using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.ReviewServiceSpec
{
    public class When_saving_review : UsingReviewServiceSpec
    {
        private Review _result;

        private Review _review;

        public override void Context()
        {
            base.Context();

            _review = new Review
            {
                reviewNumber = 11,
                rating = 72,
                content = "content"
            };

            _reviewRepository.Save(_review).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_review);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _reviewRepository.Received(1).Save(_review);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Review>();

            _result.ShouldBe(_review);
        }
    }
}