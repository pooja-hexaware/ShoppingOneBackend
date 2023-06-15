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

namespace backend.Test.Api.CommentControllerSpec
{
    public class When_updating_comment : UsingCommentControllerSpec
    {
        private ActionResult<CommentDto > _result;
        private Comment _comment;
        private CommentDto _commentDto;

        public override void Context()
        {
            base.Context();

            _comment = new Comment
            {
                commentNumber = 94,
                content = "content"
            };

            _commentDto = new CommentDto{
                    commentNumber = 13,
                    content = "content"
            };

            _commentService.Update(_comment.Id, _comment).Returns(_comment);
            _mapper.Map<CommentDto>(_comment).Returns(_commentDto);
            
        }
        public override void Because()
        {
            _result = subject.Update(_comment.Id, _comment);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _commentService.Received(1).Update(_comment.Id, _comment);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<CommentDto>();

            var resultList = resultListObject as CommentDto;

            resultList.ShouldBe(_commentDto);
        }
    }
}