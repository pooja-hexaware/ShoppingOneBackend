using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.PostServiceSpec
{
    public class When_saving_post : UsingPostServiceSpec
    {
        private Post _result;

        private Post _post;

        public override void Context()
        {
            base.Context();

            _post = new Post
            {
                postNumber = 59,
                title = "title",
                content = "content"
            };

            _postRepository.Save(_post).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_post);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _postRepository.Received(1).Save(_post);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Post>();

            _result.ShouldBe(_post);
        }
    }
}