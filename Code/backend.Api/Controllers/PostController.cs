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
    public class PostController : ControllerBase
    {
        readonly IPostService _PostService;
        private readonly IMapper _mapper;
        public PostController(IPostService PostService,IMapper mapper)
        {
            _PostService = PostService;
            _mapper = mapper;
        }

        // GET: api/Post
        [HttpGet]
        public ActionResult<IEnumerable<PostDto>> Get()
        {
            var PostDTOs = _mapper.Map<IEnumerable<PostDto>>(_PostService.GetAll());
            return Ok(PostDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<PostDto> GetById(string id)
        {
            var PostDTO = _mapper.Map<PostDto>(_PostService.Get(id));
            return Ok(PostDTO);
        }

        [HttpPost]
        public ActionResult<PostDto> Save(Post Post)
        {
            var PostDTOs = _mapper.Map<PostDto>(_PostService.Save(Post));
            return Ok(PostDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<PostDto> Update([FromRoute] string id, Post Post)
        {
            var PostDTOs = _mapper.Map<PostDto>(_PostService.Update(id, Post));
            return Ok(PostDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _PostService.Delete(id);
            return Ok(res);
    }


    }
}
