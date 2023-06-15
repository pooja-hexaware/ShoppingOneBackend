using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface IReviewService
    {      
        IEnumerable<Review> GetAll();
        Review Get(string id);
        Review Save(Review review);
        Review Update(string id, Review review);
        bool Delete(string id);

    }
}
