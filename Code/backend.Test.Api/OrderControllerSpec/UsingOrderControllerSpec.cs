using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.OrderControllerSpec
{
    public abstract class UsingOrderControllerSpec : SpecFor<OrderController>
    {
        protected IOrderService _orderService;
        protected IMapper _mapper;

        public override void Context()
        {
            _orderService = Substitute.For<IOrderService>();
            _mapper = Substitute.For<IMapper>();
            subject = new OrderController(_orderService,_mapper);

        }

    }
}
