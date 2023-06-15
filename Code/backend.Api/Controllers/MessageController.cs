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
    public class MessageController : ControllerBase
    {
        readonly IMessageService _MessageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService MessageService,IMapper mapper)
        {
            _MessageService = MessageService;
            _mapper = mapper;
        }

        // GET: api/Message
        [HttpGet]
        public ActionResult<IEnumerable<MessageDto>> Get()
        {
            var MessageDTOs = _mapper.Map<IEnumerable<MessageDto>>(_MessageService.GetAll());
            return Ok(MessageDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<MessageDto> GetById(string id)
        {
            var MessageDTO = _mapper.Map<MessageDto>(_MessageService.Get(id));
            return Ok(MessageDTO);
        }

        [HttpPost]
        public ActionResult<MessageDto> Save(Message Message)
        {
            var MessageDTOs = _mapper.Map<MessageDto>(_MessageService.Save(Message));
            return Ok(MessageDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<MessageDto> Update([FromRoute] string id, Message Message)
        {
            var MessageDTOs = _mapper.Map<MessageDto>(_MessageService.Update(id, Message));
            return Ok(MessageDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _MessageService.Delete(id);
            return Ok(res);
    }


    }
}
