using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.OrderItemServiceSpec
{
    public abstract class UsingOrderItemServiceSpec : SpecFor<OrderItemService>
    {
        protected IOrderItemRepository _orderitemRepository;

        public override void Context()
        {
            _orderitemRepository = Substitute.For<IOrderItemRepository>();
            subject = new OrderItemService(_orderitemRepository);

        }

    }
}