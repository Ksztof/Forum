using Forum.Core.Interfaces.CommentToComment;
using Forum.Core.Repositories.CommentToComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Services.CommentToComment
{
    public class CommentToCommentService : ICommentToCommentService
    {
        private CommentToCommentRepository _commentToCommentRepository = null;
        private CommentToCommentRepository CommentToCommentRepository
        {
            get
            {
                if (_commentToCommentRepository == null)
                {
                    _commentToCommentRepository = new CommentToCommentRepository();
                }
                return _commentToCommentRepository;
            }
        }


        public Domain.Models.CommentToComment Add(Domain.Models.CommentToComment entity)
        {
            return CommentToCommentRepository.Add(entity);
        }

        public bool Delete(Domain.Models.CommentToComment entity)
        {
            return CommentToCommentRepository.Delete(entity);
        }

        public Domain.Models.CommentToComment GetBy(int id)
        {
            return CommentToCommentRepository.GetBy(id);
        }

        public IEnumerable<Domain.Models.CommentToComment> GetList()
        {
            return CommentToCommentRepository.GetList();
        }

        public IList<Domain.Models.CommentToComment> GetListWithSpecificAnswerId(int answerId)
        {
            return CommentToCommentRepository.GetListWithSpecificAnswerId(answerId);
        }

        public Domain.Models.CommentToComment Update(Domain.Models.CommentToComment entity)
        {
            return CommentToCommentRepository.Update(entity);
        }
    }
}
