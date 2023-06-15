using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.PostControllerSpec
{
    public abstract class UsingPostControllerSpec : SpecFor<PostController>
    {
        protected IPostService _postService;
        protected IMapper _mapper;

        public override void Context()
        {
            _postService = Substitute.For<IPostService>();
            _mapper = Substitute.For<IMapper>();
            subject = new PostController(_postService,_mapper);

        }

    }
}
