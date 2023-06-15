using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.CommentServiceSpec
{
    public abstract class UsingCommentServiceSpec : SpecFor<CommentService>
    {
        protected ICommentRepository _commentRepository;

        public override void Context()
        {
            _commentRepository = Substitute.For<ICommentRepository>();
            subject = new CommentService(_commentRepository);

        }

    }
}