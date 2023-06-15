using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.ReviewControllerSpec
{
    public class When_getting_all_review : UsingReviewControllerSpec
    {
        private ActionResult<IEnumerable<ReviewDto>> _result;

        private IEnumerable<Review> _all_review;
        private Review _review;

        private IEnumerable<ReviewDto>  _all_reviewDto;
        private ReviewDto _reviewDto;
    

        public override void Context()
        {
            base.Context();

            _review = new Review{
                reviewNumber = 77,
                rating = 14,
                content = "content"
            };

            _reviewDto = new ReviewDto{
                    reviewNumber = 2,
                    rating = 66,
                    content = "content"
                };

            _all_review = new List<Review> { _review};
            _reviewService.GetAll().Returns(_all_review);
            _all_reviewDto  = new List<ReviewDto> {_reviewDto};
            _mapper.Map<IEnumerable<ReviewDto>>(_all_review).Returns( _all_reviewDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _reviewService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<ReviewDto>>();

            List<ReviewDto> resultList = resultListObject as List<ReviewDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_reviewDto);
        }
    }
}