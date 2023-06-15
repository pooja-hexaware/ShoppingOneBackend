using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.PostServiceSpec
{
    public class When_getting_all_post : UsingPostServiceSpec
    {
        private IEnumerable<Post> _result;

        private IEnumerable<Post> _all_post;
        private Post _post;

        public override void Context()
        {
            base.Context();

            _post = new Post{
                postNumber = 82,
                title = "title",
                content = "content"
            };

            _all_post = new List<Post> { _post};
            _postRepository.GetAll().Returns(_all_post);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _postRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Post>>();

            List<Post> resultList = _result as List<Post>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_post);
        }
    }
}