using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;
using backend.BusinessServices.Services;

namespace backend.Test.Api.MessageControllerSpec
{
    public class When_saving_message : UsingMessageControllerSpec
    {
        private ActionResult<MessageDto> _result;

        private Message _message;
        private MessageDto _messageDto;

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

            _messageDto = new MessageDto{
                    messageNumber = "messageNumber",
                    senderNumber = "senderNumber",
                    receiverNumber = "receiverNumber",
                    content = "content"
            };

            _messageService.Save(_message).Returns(_message);
            _mapper.Map<MessageDto>(_message).Returns(_messageDto);
        }
        public override void Because()
        {
            _result = subject.Save(_message);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _messageService.Received(1).Save(_message);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<MessageDto>();

            var resultList = (MessageDto)resultListObject;

            resultList.ShouldBe(_messageDto);
        }
    }
}

