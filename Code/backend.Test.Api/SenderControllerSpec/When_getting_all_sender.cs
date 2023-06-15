using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;

namespace backend.Test.Api.SenderControllerSpec
{
    public class When_getting_all_sender : UsingSenderControllerSpec
    {
        private ActionResult<IEnumerable<SenderDto>> _result;

        private IEnumerable<Sender> _all_sender;
        private Sender _sender;

        private IEnumerable<SenderDto>  _all_senderDto;
        private SenderDto _senderDto;
    

        public override void Context()
        {
            base.Context();

            _sender = new Sender{
                senderNumber = 53,
                userId = 43
            };

            _senderDto = new SenderDto{
                    senderNumber = 48,
                    userId = 54
                };

            _all_sender = new List<Sender> { _sender};
            _senderService.GetAll().Returns(_all_sender);
            _all_senderDto  = new List<SenderDto> {_senderDto};
            _mapper.Map<IEnumerable<SenderDto>>(_all_sender).Returns( _all_senderDto);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _senderService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<SenderDto>>();

            List<SenderDto> resultList = resultListObject as List<SenderDto>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_senderDto);
        }
    }
}