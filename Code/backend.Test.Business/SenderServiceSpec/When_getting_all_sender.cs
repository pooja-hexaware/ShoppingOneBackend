using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.SenderServiceSpec
{
    public class When_getting_all_sender : UsingSenderServiceSpec
    {
        private IEnumerable<Sender> _result;

        private IEnumerable<Sender> _all_sender;
        private Sender _sender;

        public override void Context()
        {
            base.Context();

            _sender = new Sender{
                senderNumber = 75,
                userId = 100
            };

            _all_sender = new List<Sender> { _sender};
            _senderRepository.GetAll().Returns(_all_sender);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _senderRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Sender>>();

            List<Sender> resultList = _result as List<Sender>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_sender);
        }
    }
}