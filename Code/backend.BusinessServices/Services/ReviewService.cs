using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class ReviewService : IReviewService
    {
        readonly IReviewRepository _ReviewRepository;

        public ReviewService(IReviewRepository ReviewRepository)
        {
           this._ReviewRepository = ReviewRepository;
        }
        public IEnumerable<Review> GetAll()
        {
            return _ReviewRepository.GetAll();
        }

        public Review Get(string id)
        {
            return _ReviewRepository.Get(id);
        }

        public Review Save(Review review)
        {
            _ReviewRepository.Save(review);
            return review;
        }

        public Review Update(string id, Review review)
        {
            return _ReviewRepository.Update(id, review);
        }

        public bool Delete(string id)
        {
            return _ReviewRepository.Delete(id);
        }

    }
}
