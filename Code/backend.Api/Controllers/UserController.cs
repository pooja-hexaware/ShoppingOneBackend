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
    public class UserController : ControllerBase
    {
        readonly IUserService _UserService;
        private readonly IMapper _mapper;
        public UserController(IUserService UserService,IMapper mapper)
        {
            _UserService = UserService;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            var UserDTOs = _mapper.Map<IEnumerable<UserDto>>(_UserService.GetAll());
            return Ok(UserDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(string id)
        {
            var UserDTO = _mapper.Map<UserDto>(_UserService.Get(id));
            return Ok(UserDTO);
        }

        [HttpPost]
        public ActionResult<UserDto> Save(User User)
        {
            var UserDTOs = _mapper.Map<UserDto>(_UserService.Save(User));
            return Ok(UserDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<UserDto> Update([FromRoute] string id, User User)
        {
            var UserDTOs = _mapper.Map<UserDto>(_UserService.Update(id, User));
            return Ok(UserDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _UserService.Delete(id);
            return Ok(res);
    }


    }
}
