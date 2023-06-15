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
    public class SenderController : ControllerBase
    {
        readonly ISenderService _SenderService;
        private readonly IMapper _mapper;
        public SenderController(ISenderService SenderService,IMapper mapper)
        {
            _SenderService = SenderService;
            _mapper = mapper;
        }

        // GET: api/Sender
        [HttpGet]
        public ActionResult<IEnumerable<SenderDto>> Get()
        {
            var SenderDTOs = _mapper.Map<IEnumerable<SenderDto>>(_SenderService.GetAll());
            return Ok(SenderDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<SenderDto> GetById(string id)
        {
            var SenderDTO = _mapper.Map<SenderDto>(_SenderService.Get(id));
            return Ok(SenderDTO);
        }

        [HttpPost]
        public ActionResult<SenderDto> Save(Sender Sender)
        {
            var SenderDTOs = _mapper.Map<SenderDto>(_SenderService.Save(Sender));
            return Ok(SenderDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<SenderDto> Update([FromRoute] string id, Sender Sender)
        {
            var SenderDTOs = _mapper.Map<SenderDto>(_SenderService.Update(id, Sender));
            return Ok(SenderDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _SenderService.Delete(id);
            return Ok(res);
    }


    }
}
