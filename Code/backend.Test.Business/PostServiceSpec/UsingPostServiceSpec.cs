using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.PostServiceSpec
{
    public abstract class UsingPostServiceSpec : SpecFor<PostService>
    {
        protected IPostRepository _postRepository;

        public override void Context()
        {
            _postRepository = Substitute.For<IPostRepository>();
            subject = new PostService(_postRepository);

        }

    }
}