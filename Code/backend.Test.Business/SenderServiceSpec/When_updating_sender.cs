using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;


namespace backend.Test.Business.SenderServiceSpec
{
    public class When_updating_sender : UsingSenderServiceSpec
    {
        private Sender _result;
        private Sender _sender;

        public override void Context()
        {
            base.Context();

            _sender = new Sender
            {
                senderNumber = 64,
                userId = 2
            };

            _senderRepository.Update(_sender.Id, _sender).Returns(_sender);
            
        }
        public override void Because()
        {
            _result = subject.Update(_sender.Id, _sender);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _senderRepository.Received(1).Update(_sender.Id, _sender);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Sender>();

            _result.ShouldBe(_sender);
        }
    }
}