using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.CommentServiceSpec
{
    public class When_saving_comment : UsingCommentServiceSpec
    {
        private Comment _result;

        private Comment _comment;

        public override void Context()
        {
            base.Context();

            _comment = new Comment
            {
                commentNumber = 4,
                content = "content"
            };

            _commentRepository.Save(_comment).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_comment);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _commentRepository.Received(1).Save(_comment);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Comment>();

            _result.ShouldBe(_comment);
        }
    }
}