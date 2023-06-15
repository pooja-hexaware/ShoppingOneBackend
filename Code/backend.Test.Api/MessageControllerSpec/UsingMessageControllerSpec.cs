using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.MessageControllerSpec
{
    public abstract class UsingMessageControllerSpec : SpecFor<MessageController>
    {
        protected IMessageService _messageService;
        protected IMapper _mapper;

        public override void Context()
        {
            _messageService = Substitute.For<IMessageService>();
            _mapper = Substitute.For<IMapper>();
            subject = new MessageController(_messageService,_mapper);

        }

    }
}
