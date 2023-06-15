using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.MessageServiceSpec
{
    public class When_getting_all_message : UsingMessageServiceSpec
    {
        private IEnumerable<Message> _result;

        private IEnumerable<Message> _all_message;
        private Message _message;

        public override void Context()
        {
            base.Context();

            _message = new Message{
                messageNumber = "messageNumber",
                senderNumber = "senderNumber",
                receiverNumber = "receiverNumber",
                content = "content"
            };

            _all_message = new List<Message> { _message};
            _messageRepository.GetAll().Returns(_all_message);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _messageRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Message>>();

            List<Message> resultList = _result as List<Message>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_message);
        }
    }
}