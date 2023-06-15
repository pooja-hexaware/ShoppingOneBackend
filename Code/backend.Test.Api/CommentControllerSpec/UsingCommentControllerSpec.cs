using NSubstitute;
using backend.Test.Framework;
using backend.Api.Controllers;
using backend.BusinessServices.Interfaces;
using AutoMapper;
using backend.BusinessEntities.Entities;
using backend.Contracts.DTO;


namespace backend.Test.Api.CommentControllerSpec
{
    public abstract class UsingCommentControllerSpec : SpecFor<CommentController>
    {
        protected ICommentService _commentService;
        protected IMapper _mapper;

        public override void Context()
        {
            _commentService = Substitute.For<ICommentService>();
            _mapper = Substitute.For<IMapper>();
            subject = new CommentController(_commentService,_mapper);

        }

    }
}
