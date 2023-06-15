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
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService CategoryService,IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }

        // GET: api/Category
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            var CategoryDTOs = _mapper.Map<IEnumerable<CategoryDto>>(_CategoryService.GetAll());
            return Ok(CategoryDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetById(string id)
        {
            var CategoryDTO = _mapper.Map<CategoryDto>(_CategoryService.Get(id));
            return Ok(CategoryDTO);
        }

        [HttpPost]
        public ActionResult<CategoryDto> Save(Category Category)
        {
            var CategoryDTOs = _mapper.Map<CategoryDto>(_CategoryService.Save(Category));
            return Ok(CategoryDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryDto> Update([FromRoute] string id, Category Category)
        {
            var CategoryDTOs = _mapper.Map<CategoryDto>(_CategoryService.Update(id, Category));
            return Ok(CategoryDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _CategoryService.Delete(id);
            return Ok(res);
    }


    }
}
