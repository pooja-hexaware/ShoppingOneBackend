using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface IPostRepository : IGetAll<Post>,IGet<Post,string>, ISave<Post>, IUpdate<Post, string>, IDelete<string>
    {
    }
}
