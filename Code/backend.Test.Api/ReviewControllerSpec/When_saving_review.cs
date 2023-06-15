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
    public class When_saving_review : UsingReviewControllerSpec
    {
        private ActionResult<ReviewDto> _result;

        private Review _review;
        private ReviewDto _reviewDto;

        public override void Context()
        {
            base.Context();

            _review = new Review
            {
                reviewNumber = 41,
                rating = 36,
                content = "content"
            };

            _reviewDto = new ReviewDto{
                    reviewNumber = 41,
                    rating = 43,
                    content = "content"
            };

            _reviewService.Save(_review).Returns(_review);
            _mapper.Map<ReviewDto>(_review).Returns(_reviewDto);
        }
        public override void Because()
        {
            _result = subject.Save(_review);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _reviewService.Received(1).Save(_review);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<ReviewDto>();

            var resultList = (ReviewDto)resultListObject;

            resultList.ShouldBe(_reviewDto);
        }
    }
}

