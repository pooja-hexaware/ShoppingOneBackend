using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.ReceiverServiceSpec
{
    public abstract class UsingReceiverServiceSpec : SpecFor<ReceiverService>
    {
        protected IReceiverRepository _receiverRepository;

        public override void Context()
        {
            _receiverRepository = Substitute.For<IReceiverRepository>();
            subject = new ReceiverService(_receiverRepository);

        }

    }
}