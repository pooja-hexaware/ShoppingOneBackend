using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface ICommentRepository : IGetAll<Comment>,IGet<Comment,string>, ISave<Comment>, IUpdate<Comment, string>, IDelete<string>
    {
    }
}
