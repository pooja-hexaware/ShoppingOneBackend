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

namespace backend.Test.Api.PostControllerSpec
{
    public class When_saving_post : UsingPostControllerSpec
    {
        private ActionResult<PostDto> _result;

        private Post _post;
        private PostDto _postDto;

        public override void Context()
        {
            base.Context();

            _post = new Post
            {
                postNumber = 9,
                title = "title",
                content = "content"
            };

            _postDto = new PostDto{
                    postNumber = 95,
                    title = "title",
                    content = "content"
            };

            _postService.Save(_post).Returns(_post);
            _mapper.Map<PostDto>(_post).Returns(_postDto);
        }
        public override void Because()
        {
            _result = subject.Save(_post);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _postService.Received(1).Save(_post);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<PostDto>();

            var resultList = (PostDto)resultListObject;

            resultList.ShouldBe(_postDto);
        }
    }
}

