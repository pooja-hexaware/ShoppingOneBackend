using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using backend.BusinessEntities.Entities;

namespace backend.Test.Business.ReceiverServiceSpec
{
    public class When_getting_all_receiver : UsingReceiverServiceSpec
    {
        private IEnumerable<Receiver> _result;

        private IEnumerable<Receiver> _all_receiver;
        private Receiver _receiver;

        public override void Context()
        {
            base.Context();

            _receiver = new Receiver{
                receiverNumber = 75,
                userId = 29
            };

            _all_receiver = new List<Receiver> { _receiver};
            _receiverRepository.GetAll().Returns(_all_receiver);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _receiverRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Receiver>>();

            List<Receiver> resultList = _result as List<Receiver>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_receiver);
        }
    }
}