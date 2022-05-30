using Forum.Core.Interfaces.BaseInterface;
using Forum.Core.Interfaces.CommentToAnswer;
using Forum.Core.Repositories.CommentToAnswer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentToAnswerClass = Forum.Domain.Models.CommentToAnswer;
namespace Forum.Core.Services.CommentToAnswer
{
    public class CommentToAnswerService : ICommentToAnswerService
    {
        private CommentToAnswerRepository _commentToAnswerRepository = null;
        private CommentToAnswerRepository CommentToAnswerRepository
        {
            get
            {
                if (_commentToAnswerRepository == null)
                {
                    _commentToAnswerRepository = new CommentToAnswerRepository();
                }
                return _commentToAnswerRepository;
            }
        }

        public CommentToAnswerClass Add(CommentToAnswerClass entity)
        {
            return CommentToAnswerRepository.Add(entity);
        }


        public bool Delete(CommentToAnswerClass entity)
        {
            var commentToAnswerToDelete = CommentToAnswerRepository.Delete(entity);

            if (commentToAnswerToDelete != true)
            {
                return false;
            }

            return true;
        }


        public CommentToAnswerClass GetBy(int id)
        {
            return CommentToAnswerRepository.GetBy(id);
        }

        public IEnumerable<CommentToAnswerClass> GetList()
        {
            return CommentToAnswerRepository.GetList();
        }


        public IList<CommentToAnswerClass> GetListWithSpecificAnswerId(int answerId)
        {
            return CommentToAnswerRepository.GetListWithSpecificAnswerId(answerId);
        }


        public CommentToAnswerClass Update(CommentToAnswerClass entity)
        {
            return CommentToAnswerRepository.Update(entity);
        }
    }
}
