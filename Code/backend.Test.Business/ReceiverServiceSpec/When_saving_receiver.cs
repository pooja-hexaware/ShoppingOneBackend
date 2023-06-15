using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.ReceiverServiceSpec
{
    public class When_saving_receiver : UsingReceiverServiceSpec
    {
        private Receiver _result;

        private Receiver _receiver;

        public override void Context()
        {
            base.Context();

            _receiver = new Receiver
            {
                receiverNumber = 57,
                userId = 64
            };

            _receiverRepository.Save(_receiver).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_receiver);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _receiverRepository.Received(1).Save(_receiver);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Receiver>();

            _result.ShouldBe(_receiver);
        }
    }
}