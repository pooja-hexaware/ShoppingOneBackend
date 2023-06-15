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
    public class OrderController : ControllerBase
    {
        readonly IOrderService _OrderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService OrderService,IMapper mapper)
        {
            _OrderService = OrderService;
            _mapper = mapper;
        }

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> Get()
        {
            var OrderDTOs = _mapper.Map<IEnumerable<OrderDto>>(_OrderService.GetAll());
            return Ok(OrderDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetById(string id)
        {
            var OrderDTO = _mapper.Map<OrderDto>(_OrderService.Get(id));
            return Ok(OrderDTO);
        }

        [HttpPost]
        public ActionResult<OrderDto> Save(Order Order)
        {
            var OrderDTOs = _mapper.Map<OrderDto>(_OrderService.Save(Order));
            return Ok(OrderDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<OrderDto> Update([FromRoute] string id, Order Order)
        {
            var OrderDTOs = _mapper.Map<OrderDto>(_OrderService.Update(id, Order));
            return Ok(OrderDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _OrderService.Delete(id);
            return Ok(res);
    }


    }
}
