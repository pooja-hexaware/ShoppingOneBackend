using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.MessageServiceSpec
{
    public abstract class UsingMessageServiceSpec : SpecFor<MessageService>
    {
        protected IMessageRepository _messageRepository;

        public override void Context()
        {
            _messageRepository = Substitute.For<IMessageRepository>();
            subject = new MessageService(_messageRepository);

        }

    }
}