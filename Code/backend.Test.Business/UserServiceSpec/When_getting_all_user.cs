using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.UserServiceSpec
{
    public class When_getting_all_user : UsingUserServiceSpec
    {
        private IEnumerable<User> _result;

        private IEnumerable<User> _all_user;
        private User _user;

        public override void Context()
        {
            base.Context();

            _user = new User{
                userId = 37,
                username = "username",
                email = 22.57,
                password = 87,
                doj = new DateTime()
            };

            _all_user = new List<User> { _user};
            _userRepository.GetAll().Returns(_all_user);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _userRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<User>>();

            List<User> resultList = _result as List<User>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_user);
        }
    }
}