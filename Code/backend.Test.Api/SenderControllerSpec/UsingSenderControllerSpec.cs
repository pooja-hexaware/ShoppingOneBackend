using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.SenderControllerSpec
{
    public abstract class UsingSenderControllerSpec : SpecFor<SenderController>
    {
        protected ISenderService _senderService;
        protected IMapper _mapper;

        public override void Context()
        {
            _senderService = Substitute.For<ISenderService>();
            _mapper = Substitute.For<IMapper>();
            subject = new SenderController(_senderService,_mapper);

        }

    }
}
