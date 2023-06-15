using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.PostControllerSpec
{
    public class When_getting_all_post : UsingPostControllerSpec
    {
        private ActionResult<IEnumerable<PostDto>> _result;

        private IEnumerable<Post> _all_post;
        private Post _post;

        private IEnumerable<PostDto>  _all_postDto;
        private PostDto _postDto;
    

        public override void Context()
        {
            base.Context();

            _post = new Post{
                postNumber = 72,
                title = "title",
                content = "content"
            };

            _postDto = new PostDto{
                    postNumber = 26,
                    title = "title",
                    content = "content"
                };

            _all_post = new List<Post> { _post};
            _postService.GetAll().Returns(_all_post);
            _all_postDto  = new List<PostDto> {_postDto};
            _mapper.Map<IEnumerable<PostDto>>(_all_post).Returns( _all_postDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _postService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<PostDto>>();

            List<PostDto> resultList = resultListObject as List<PostDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_postDto);
        }
    }
}