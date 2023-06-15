using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.ReviewServiceSpec
{
    public class When_getting_all_review : UsingReviewServiceSpec
    {
        private IEnumerable<Review> _result;

        private IEnumerable<Review> _all_review;
        private Review _review;

        public override void Context()
        {
            base.Context();

            _review = new Review{
                reviewNumber = 51,
                rating = 99,
                content = "content"
            };

            _all_review = new List<Review> { _review};
            _reviewRepository.GetAll().Returns(_all_review);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _reviewRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Review>>();

            List<Review> resultList = _result as List<Review>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_review);
        }
    }
}