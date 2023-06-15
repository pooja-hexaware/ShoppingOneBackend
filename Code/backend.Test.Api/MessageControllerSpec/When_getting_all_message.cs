using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.MessageControllerSpec
{
    public class When_getting_all_message : UsingMessageControllerSpec
    {
        private ActionResult<IEnumerable<MessageDto>> _result;

        private IEnumerable<Message> _all_message;
        private Message _message;

        private IEnumerable<MessageDto>  _all_messageDto;
        private MessageDto _messageDto;
    

        public override void Context()
        {
            base.Context();

            _message = new Message{
                messageNumber = "messageNumber",
                senderNumber = "senderNumber",
                receiverNumber = "receiverNumber",
                content = "content"
            };

            _messageDto = new MessageDto{
                    messageNumber = "messageNumber",
                    senderNumber = "senderNumber",
                    receiverNumber = "receiverNumber",
                    content = "content"
                };

            _all_message = new List<Message> { _message};
            _messageService.GetAll().Returns(_all_message);
            _all_messageDto  = new List<MessageDto> {_messageDto};
            _mapper.Map<IEnumerable<MessageDto>>(_all_message).Returns( _all_messageDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _messageService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<MessageDto>>();

            List<MessageDto> resultList = resultListObject as List<MessageDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_messageDto);
        }
    }
}