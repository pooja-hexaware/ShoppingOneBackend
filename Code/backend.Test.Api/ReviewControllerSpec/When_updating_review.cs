using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;
using backend.BusinessServices.Services;

namespace backend.Test.Api.ReviewControllerSpec
{
    public class When_updating_review : UsingReviewControllerSpec
    {
        private ActionResult<ReviewDto > _result;
        private Review _review;
        private ReviewDto _reviewDto;

        public override void Context()
        {
            base.Context();

            _review = new Review
            {
                reviewNumber = 17,
                rating = 48,
                content = "content"
            };

            _reviewDto = new ReviewDto{
                    reviewNumber = 16,
                    rating = 39,
                    content = "content"
            };

            _reviewService.Update(_review.Id, _review).Returns(_review);
            _mapper.Map<ReviewDto>(_review).Returns(_reviewDto);
            
        }
        public override void Because()
        {
            _result = subject.Update(_review.Id, _review);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _reviewService.Received(1).Update(_review.Id, _review);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<ReviewDto>();

            var resultList = resultListObject as ReviewDto;

            resultList.ShouldBe(_reviewDto);
        }
    }
}