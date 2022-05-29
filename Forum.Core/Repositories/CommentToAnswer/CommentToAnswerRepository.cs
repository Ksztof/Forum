using Forum.Core.Interfaces.BaseInterface;
using Forum.Core.Interfaces.CommentToAnswer;
using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Repositories.CommentToAnswer
{
    public class CommentToAnswerRepository : Repository, ICommentToAnswerRepository
    {
        public Domain.CommentToAnswer Add(Domain.CommentToAnswer entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var CommentToAnswer = db.CommentsToAnswer.Add(entity);
                db.SaveChanges();
                return CommentToAnswer.Entity;
            }
        }

        public bool Delete(Domain.CommentToAnswer entity)
        {
            using (ForumDb db = new ForumDb())
            {
                if (!db.CommentsToAnswer.Any(x => x.Id == entity.Id))
                {
                    return false;
                }

                var CommentToAnswer = db.CommentsToAnswer.Remove(entity);
                db.SaveChanges();
                return true;
            }
        }

        public Domain.CommentToAnswer GetBy(int id)
        {
            using (ForumDb db = new ForumDb())
            {
                var commentToAnswer = db.CommentsToAnswer.Where(x => x.Id == id).First();
                return commentToAnswer;
            }
        }

        public IEnumerable<Domain.CommentToAnswer> GetList()
        {
            using (ForumDb db = new ForumDb())
            {
                var commentToAnswer = db.CommentsToAnswer.OrderBy(x => x.Id);
                return commentToAnswer.ToList();
            }
        }

        public IList<Domain.CommentToAnswer> GetListWithSpecificAnswerId(int answerId)
        {
            using (ForumDb db = new ForumDb())
            {
                var commentToAnswer = db.CommentsToAnswer.Where(x => x.AnswerId == answerId).OrderBy(x => x.Id);
                return commentToAnswer.ToList();
            }
        }

        public Domain.CommentToAnswer Update(Domain.CommentToAnswer entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var commentToAnswer = db.CommentsToAnswer.Update(entity);
                db.SaveChanges();
                return commentToAnswer.Entity;
            }
        }
    }
}
