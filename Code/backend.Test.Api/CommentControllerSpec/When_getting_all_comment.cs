using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.CommentControllerSpec
{
    public class When_getting_all_comment : UsingCommentControllerSpec
    {
        private ActionResult<IEnumerable<CommentDto>> _result;

        private IEnumerable<Comment> _all_comment;
        private Comment _comment;

        private IEnumerable<CommentDto>  _all_commentDto;
        private CommentDto _commentDto;
    

        public override void Context()
        {
            base.Context();

            _comment = new Comment{
                commentNumber = 93,
                content = "content"
            };

            _commentDto = new CommentDto{
                    commentNumber = 100,
                    content = "content"
                };

            _all_comment = new List<Comment> { _comment};
            _commentService.GetAll().Returns(_all_comment);
            _all_commentDto  = new List<CommentDto> {_commentDto};
            _mapper.Map<IEnumerable<CommentDto>>(_all_comment).Returns( _all_commentDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _commentService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<CommentDto>>();

            List<CommentDto> resultList = resultListObject as List<CommentDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_commentDto);
        }
    }
}