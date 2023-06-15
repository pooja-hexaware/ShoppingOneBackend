using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;


namespace backend.Test.Business.MessageServiceSpec
{
    public class When_updating_message : UsingMessageServiceSpec
    {
        private Message _result;
        private Message _message;

        public override void Context()
        {
            base.Context();

            _message = new Message
            {
                messageNumber = "messageNumber",
                senderNumber = "senderNumber",
                receiverNumber = "receiverNumber",
                content = "content"
            };

            _messageRepository.Update(_message.Id, _message).Returns(_message);
            
        }
        public override void Because()
        {
            _result = subject.Update(_message.Id, _message);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _messageRepository.Received(1).Update(_message.Id, _message);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Message>();

            _result.ShouldBe(_message);
        }
    }
}