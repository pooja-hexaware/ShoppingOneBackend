using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
           this._UserRepository = UserRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return _UserRepository.GetAll();
        }

        public User Get(string id)
        {
            return _UserRepository.Get(id);
        }

        public User Save(User user)
        {
            _UserRepository.Save(user);
            return user;
        }

        public User Update(string id, User user)
        {
            return _UserRepository.Update(id, user);
        }

        public bool Delete(string id)
        {
            return _UserRepository.Delete(id);
        }

    }
}
