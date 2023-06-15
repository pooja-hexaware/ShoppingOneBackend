using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class CommentService : ICommentService
    {
        readonly ICommentRepository _CommentRepository;

        public CommentService(ICommentRepository CommentRepository)
        {
           this._CommentRepository = CommentRepository;
        }
        public IEnumerable<Comment> GetAll()
        {
            return _CommentRepository.GetAll();
        }

        public Comment Get(string id)
        {
            return _CommentRepository.Get(id);
        }

        public Comment Save(Comment comment)
        {
            _CommentRepository.Save(comment);
            return comment;
        }

        public Comment Update(string id, Comment comment)
        {
            return _CommentRepository.Update(id, comment);
        }

        public bool Delete(string id)
        {
            return _CommentRepository.Delete(id);
        }

    }
}
