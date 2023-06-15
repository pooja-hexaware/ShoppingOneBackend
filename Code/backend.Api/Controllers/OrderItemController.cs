using System.Collections.Generic;
using backend.BusinessServices.Interfaces;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace backend.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        readonly IOrderItemService _OrderItemService;
        private readonly IMapper _mapper;
        public OrderItemController(IOrderItemService OrderItemService,IMapper mapper)
        {
            _OrderItemService = OrderItemService;
            _mapper = mapper;
        }

        // GET: api/OrderItem
        [HttpGet]
        public ActionResult<IEnumerable<OrderItemDto>> Get()
        {
            var OrderItemDTOs = _mapper.Map<IEnumerable<OrderItemDto>>(_OrderItemService.GetAll());
            return Ok(OrderItemDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderItemDto> GetById(string id)
        {
            var OrderItemDTO = _mapper.Map<OrderItemDto>(_OrderItemService.Get(id));
            return Ok(OrderItemDTO);
        }

        [HttpPost]
        public ActionResult<OrderItemDto> Save(OrderItem OrderItem)
        {
            var OrderItemDTOs = _mapper.Map<OrderItemDto>(_OrderItemService.Save(OrderItem));
            return Ok(OrderItemDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<OrderItemDto> Update([FromRoute] string id, OrderItem OrderItem)
        {
            var OrderItemDTOs = _mapper.Map<OrderItemDto>(_OrderItemService.Update(id, OrderItem));
            return Ok(OrderItemDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _OrderItemService.Delete(id);
            return Ok(res);
    }


    }
}
