using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface IPostService
    {      
        IEnumerable<Post> GetAll();
        Post Get(string id);
        Post Save(Post post);
        Post Update(string id, Post post);
        bool Delete(string id);

    }
}
