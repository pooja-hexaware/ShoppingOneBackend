using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.SenderServiceSpec
{
    public abstract class UsingSenderServiceSpec : SpecFor<SenderService>
    {
        protected ISenderRepository _senderRepository;

        public override void Context()
        {
            _senderRepository = Substitute.For<ISenderRepository>();
            subject = new SenderService(_senderRepository);

        }

    }
}