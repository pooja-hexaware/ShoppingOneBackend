using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface IReviewRepository : IGetAll<Review>,IGet<Review,string>, ISave<Review>, IUpdate<Review, string>, IDelete<string>
    {
    }
}
