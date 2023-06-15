using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;


namespace backend.Test.Business.CommentServiceSpec
{
    public class When_updating_comment : UsingCommentServiceSpec
    {
        private Comment _result;
        private Comment _comment;

        public override void Context()
        {
            base.Context();

            _comment = new Comment
            {
                commentNumber = 63,
                content = "content"
            };

            _commentRepository.Update(_comment.Id, _comment).Returns(_comment);
            
        }
        public override void Because()
        {
            _result = subject.Update(_comment.Id, _comment);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _commentRepository.Received(1).Update(_comment.Id, _comment);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Comment>();

            _result.ShouldBe(_comment);
        }
    }
}