using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.CommentServiceSpec
{
    public class When_getting_all_comment : UsingCommentServiceSpec
    {
        private IEnumerable<Comment> _result;

        private IEnumerable<Comment> _all_comment;
        private Comment _comment;

        public override void Context()
        {
            base.Context();

            _comment = new Comment{
                commentNumber = 50,
                content = "content"
            };

            _all_comment = new List<Comment> { _comment};
            _commentRepository.GetAll().Returns(_all_comment);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _commentRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Comment>>();

            List<Comment> resultList = _result as List<Comment>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_comment);
        }
    }
}