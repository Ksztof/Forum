using Forum.Core.Interfaces.BaseInterface;
using Forum.Core.Interfaces.CommentToComment;
using Forum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Repositories.CommentToComment
{
    internal class CommentToCommentRepository : Repository, ICommentToCommentRepository
    {
        public Domain.Models.CommentToComment Add(Domain.Models.CommentToComment entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var commentToComment= db.CommentsToComment.Add(entity);
                db.SaveChanges();
                return commentToComment.Entity;
            }
        }

        public bool Delete(Domain.Models.CommentToComment entity)
        {
            using (ForumDb db = new ForumDb())
            {
                if (!db.CommentsToComment.Any(x => x.Id == entity.Id))
                {
                    return false;
                }

                var commentToComment = db.CommentsToComment.Remove(entity);
                db.SaveChanges();
                return true;
            }
        }

        public Domain.Models.CommentToComment GetBy(int id)
        {
            using (ForumDb db = new ForumDb())
            {
                var commentToComment = db.CommentsToComment.Where(x => x.Id == id).First();
                return commentToComment;
            }
        }

        public IEnumerable<Domain.Models.CommentToComment> GetList()
        {
            using (ForumDb db = new ForumDb())
            {
                var commentToComment = db.CommentsToComment.OrderBy(x => x.Id);
                return commentToComment.ToList();
            }
        }

        public IList<Domain.Models.CommentToComment> GetListWithSpecificAnswerId(int answerId)
        {
            using (ForumDb db = new ForumDb())
            {
                var commentToComment = db.CommentsToComment.Where(x => x.CommentToAnswerId == answerId).OrderBy(x => x.Id);
                return commentToComment.ToList();
            }
        }

        public Domain.Models.CommentToComment Update(Domain.Models.CommentToComment entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var commentToComment = db.CommentsToComment.Update(entity);
                db.SaveChanges();
                return commentToComment.Entity;
            }
        }
    }
}
