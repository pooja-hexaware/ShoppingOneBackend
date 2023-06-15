using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.OrderItemControllerSpec
{
    public abstract class UsingOrderItemControllerSpec : SpecFor<OrderItemController>
    {
        protected IOrderItemService _orderitemService;
        protected IMapper _mapper;

        public override void Context()
        {
            _orderitemService = Substitute.For<IOrderItemService>();
            _mapper = Substitute.For<IMapper>();
            subject = new OrderItemController(_orderitemService,_mapper);

        }

    }
}
