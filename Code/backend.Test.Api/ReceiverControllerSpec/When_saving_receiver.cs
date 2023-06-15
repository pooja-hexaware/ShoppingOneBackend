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

namespace backend.Test.Api.ReceiverControllerSpec
{
    public class When_saving_receiver : UsingReceiverControllerSpec
    {
        private ActionResult<ReceiverDto> _result;

        private Receiver _receiver;
        private ReceiverDto _receiverDto;

        public override void Context()
        {
            base.Context();

            _receiver = new Receiver
            {
                receiverNumber = 81,
                userId = 73
            };

            _receiverDto = new ReceiverDto{
                    receiverNumber = 37,
                    userId = 44
            };

            _receiverService.Save(_receiver).Returns(_receiver);
            _mapper.Map<ReceiverDto>(_receiver).Returns(_receiverDto);
        }
        public override void Because()
        {
            _result = subject.Save(_receiver);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _receiverService.Received(1).Save(_receiver);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<ReceiverDto>();

            var resultList = (ReceiverDto)resultListObject;

            resultList.ShouldBe(_receiverDto);
        }
    }
}

