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
    public class ReviewController : ControllerBase
    {
        readonly IReviewService _ReviewService;
        private readonly IMapper _mapper;
        public ReviewController(IReviewService ReviewService,IMapper mapper)
        {
            _ReviewService = ReviewService;
            _mapper = mapper;
        }

        // GET: api/Review
        [HttpGet]
        public ActionResult<IEnumerable<ReviewDto>> Get()
        {
            var ReviewDTOs = _mapper.Map<IEnumerable<ReviewDto>>(_ReviewService.GetAll());
            return Ok(ReviewDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<ReviewDto> GetById(string id)
        {
            var ReviewDTO = _mapper.Map<ReviewDto>(_ReviewService.Get(id));
            return Ok(ReviewDTO);
        }

        [HttpPost]
        public ActionResult<ReviewDto> Save(Review Review)
        {
            var ReviewDTOs = _mapper.Map<ReviewDto>(_ReviewService.Save(Review));
            return Ok(ReviewDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<ReviewDto> Update([FromRoute] string id, Review Review)
        {
            var ReviewDTOs = _mapper.Map<ReviewDto>(_ReviewService.Update(id, Review));
            return Ok(ReviewDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _ReviewService.Delete(id);
            return Ok(res);
    }


    }
}
