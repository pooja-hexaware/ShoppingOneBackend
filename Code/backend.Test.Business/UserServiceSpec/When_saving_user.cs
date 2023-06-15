using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.UserServiceSpec
{
    public class When_saving_user : UsingUserServiceSpec
    {
        private User _result;

        private User _user;

        public override void Context()
        {
            base.Context();

            _user = new User
            {
                userId = 79,
                username = "username",
                email = 35.29,
                password = 75,
                doj = new DateTime()
            };

            _userRepository.Save(_user).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_user);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _userRepository.Received(1).Save(_user);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<User>();

            _result.ShouldBe(_user);
        }
    }
}