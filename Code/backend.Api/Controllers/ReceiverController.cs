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
    public class ReceiverController : ControllerBase
    {
        readonly IReceiverService _ReceiverService;
        private readonly IMapper _mapper;
        public ReceiverController(IReceiverService ReceiverService,IMapper mapper)
        {
            _ReceiverService = ReceiverService;
            _mapper = mapper;
        }

        // GET: api/Receiver
        [HttpGet]
        public ActionResult<IEnumerable<ReceiverDto>> Get()
        {
            var ReceiverDTOs = _mapper.Map<IEnumerable<ReceiverDto>>(_ReceiverService.GetAll());
            return Ok(ReceiverDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<ReceiverDto> GetById(string id)
        {
            var ReceiverDTO = _mapper.Map<ReceiverDto>(_ReceiverService.Get(id));
            return Ok(ReceiverDTO);
        }

        [HttpPost]
        public ActionResult<ReceiverDto> Save(Receiver Receiver)
        {
            var ReceiverDTOs = _mapper.Map<ReceiverDto>(_ReceiverService.Save(Receiver));
            return Ok(ReceiverDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<ReceiverDto> Update([FromRoute] string id, Receiver Receiver)
        {
            var ReceiverDTOs = _mapper.Map<ReceiverDto>(_ReceiverService.Update(id, Receiver));
            return Ok(ReceiverDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _ReceiverService.Delete(id);
            return Ok(res);
    }


    }
}
