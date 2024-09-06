using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class CommentService
    {
        private readonly MovieDBContext _context;

        public CommentService(MovieDBContext context)
        {
            _context = context;
        }
        public void Create(int idMovie, int idUser, string text)
        {
            Comment comment = new Comment() { IdMovie = idMovie, IdUser = idUser, Text = text };
            CommentRepository _repository = new CommentRepository(_context);
            _repository.Create(comment);
        }

        public bool Update(int idUser, int idComment, Comment comment)
        {
            CommentRepository _repository = new CommentRepository(_context);
            if (_repository.GetById(idComment).IdUser == idUser)
            {
                try
                {
                    _repository.Update(comment, idComment);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int idUser, int idComment)
        {
            CommentRepository _repository = new CommentRepository(_context);
            var comment = _repository.GetById(idComment);
            if (comment != null && comment.IdUser == idUser)
            {
                try
                {
                    _repository.Delete(comment);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
