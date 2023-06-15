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
    public class ProductController : ControllerBase
    {
        readonly IProductService _ProductService;
        private readonly IMapper _mapper;
        public ProductController(IProductService ProductService,IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            var ProductDTOs = _mapper.Map<IEnumerable<ProductDto>>(_ProductService.GetAll());
            return Ok(ProductDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(string id)
        {
            var ProductDTO = _mapper.Map<ProductDto>(_ProductService.Get(id));
            return Ok(ProductDTO);
        }

        [HttpPost]
        public ActionResult<ProductDto> Save(Product Product)
        {
            var ProductDTOs = _mapper.Map<ProductDto>(_ProductService.Save(Product));
            return Ok(ProductDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDto> Update([FromRoute] string id, Product Product)
        {
            var ProductDTOs = _mapper.Map<ProductDto>(_ProductService.Update(id, Product));
            return Ok(ProductDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _ProductService.Delete(id);
            return Ok(res);
    }


    }
}
