using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.ReceiverControllerSpec
{
    public abstract class UsingReceiverControllerSpec : SpecFor<ReceiverController>
    {
        protected IReceiverService _receiverService;
        protected IMapper _mapper;

        public override void Context()
        {
            _receiverService = Substitute.For<IReceiverService>();
            _mapper = Substitute.For<IMapper>();
            subject = new ReceiverController(_receiverService,_mapper);

        }

    }
}
