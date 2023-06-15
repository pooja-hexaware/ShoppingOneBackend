using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface ICategoryRepository : IGetAll<Category>,IGet<Category,string>, ISave<Category>, IUpdate<Category, string>, IDelete<string>
    {
    }
}
