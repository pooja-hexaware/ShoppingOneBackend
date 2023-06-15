using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class PostService : IPostService
    {
        readonly IPostRepository _PostRepository;

        public PostService(IPostRepository PostRepository)
        {
           this._PostRepository = PostRepository;
        }
        public IEnumerable<Post> GetAll()
        {
            return _PostRepository.GetAll();
        }

        public Post Get(string id)
        {
            return _PostRepository.Get(id);
        }

        public Post Save(Post post)
        {
            _PostRepository.Save(post);
            return post;
        }

        public Post Update(string id, Post post)
        {
            return _PostRepository.Update(id, post);
        }

        public bool Delete(string id)
        {
            return _PostRepository.Delete(id);
        }

    }
}
