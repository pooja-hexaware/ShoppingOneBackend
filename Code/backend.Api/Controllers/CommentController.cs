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
    public class CommentController : ControllerBase
    {
        readonly ICommentService _CommentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService CommentService,IMapper mapper)
        {
            _CommentService = CommentService;
            _mapper = mapper;
        }

        // GET: api/Comment
        [HttpGet]
        public ActionResult<IEnumerable<CommentDto>> Get()
        {
            var CommentDTOs = _mapper.Map<IEnumerable<CommentDto>>(_CommentService.GetAll());
            return Ok(CommentDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<CommentDto> GetById(string id)
        {
            var CommentDTO = _mapper.Map<CommentDto>(_CommentService.Get(id));
            return Ok(CommentDTO);
        }

        [HttpPost]
        public ActionResult<CommentDto> Save(Comment Comment)
        {
            var CommentDTOs = _mapper.Map<CommentDto>(_CommentService.Save(Comment));
            return Ok(CommentDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<CommentDto> Update([FromRoute] string id, Comment Comment)
        {
            var CommentDTOs = _mapper.Map<CommentDto>(_CommentService.Update(id, Comment));
            return Ok(CommentDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _CommentService.Delete(id);
            return Ok(res);
    }


    }
}
