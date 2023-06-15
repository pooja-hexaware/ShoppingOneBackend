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

namespace backend.Test.Api.SenderControllerSpec
{
    public class When_saving_sender : UsingSenderControllerSpec
    {
        private ActionResult<SenderDto> _result;

        private Sender _sender;
        private SenderDto _senderDto;

        public override void Context()
        {
            base.Context();

            _sender = new Sender
            {
                senderNumber = 45,
                userId = 32
            };

            _senderDto = new SenderDto{
                    senderNumber = 82,
                    userId = 86
            };

            _senderService.Save(_sender).Returns(_sender);
            _mapper.Map<SenderDto>(_sender).Returns(_senderDto);
        }
        public override void Because()
        {
            _result = subject.Save(_sender);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _senderService.Received(1).Save(_sender);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<SenderDto>();

            var resultList = (SenderDto)resultListObject;

            resultList.ShouldBe(_senderDto);
        }
    }
}

