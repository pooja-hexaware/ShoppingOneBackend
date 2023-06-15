using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface IUserService
    {      
        IEnumerable<User> GetAll();
        User Get(string id);
        User Save(User user);
        User Update(string id, User user);
        bool Delete(string id);

    }
}
