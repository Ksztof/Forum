using Forum.Core.Interfaces.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentToCommentC = Forum.Domain.Models.CommentToComment;
namespace Forum.Core.Interfaces.CommentToComment
{
    public interface ICommentToCommentRepository : IRepository<CommentToCommentC>
    {
        public IList<CommentToCommentC> GetListWithSpecificAnswerId(int answerId);
    }
}
