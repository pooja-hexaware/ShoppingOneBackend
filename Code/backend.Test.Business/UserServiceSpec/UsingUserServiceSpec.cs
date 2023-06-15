using NSubstitute;
using backend.Test.Framework;
using backend.BusinessServices.Services;
using backend.Data.Interfaces;

namespace backend.Test.Business.UserServiceSpec
{
    public abstract class UsingUserServiceSpec : SpecFor<UserService>
    {
        protected IUserRepository _userRepository;

        public override void Context()
        {
            _userRepository = Substitute.For<IUserRepository>();
            subject = new UserService(_userRepository);

        }

    }
}