using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface ICommentService
    {      
        IEnumerable<Comment> GetAll();
        Comment Get(string id);
        Comment Save(Comment comment);
        Comment Update(string id, Comment comment);
        bool Delete(string id);

    }
}
