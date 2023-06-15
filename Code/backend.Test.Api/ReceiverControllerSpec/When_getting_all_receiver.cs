using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.ReceiverControllerSpec
{
    public class When_getting_all_receiver : UsingReceiverControllerSpec
    {
        private ActionResult<IEnumerable<ReceiverDto>> _result;

        private IEnumerable<Receiver> _all_receiver;
        private Receiver _receiver;

        private IEnumerable<ReceiverDto>  _all_receiverDto;
        private ReceiverDto _receiverDto;
    

        public override void Context()
        {
            base.Context();

            _receiver = new Receiver{
                receiverNumber = 30,
                userId = 91
            };

            _receiverDto = new ReceiverDto{
                    receiverNumber = 85,
                    userId = 57
                };

            _all_receiver = new List<Receiver> { _receiver};
            _receiverService.GetAll().Returns(_all_receiver);
            _all_receiverDto  = new List<ReceiverDto> {_receiverDto};
            _mapper.Map<IEnumerable<ReceiverDto>>(_all_receiver).Returns( _all_receiverDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _receiverService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<ReceiverDto>>();

            List<ReceiverDto> resultList = resultListObject as List<ReceiverDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_receiverDto);
        }
    }
}