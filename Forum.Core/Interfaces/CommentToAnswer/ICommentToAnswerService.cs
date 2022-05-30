using Forum.Core.Interfaces.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentToAnswerClass = Forum.Domain.Models.CommentToAnswer;
namespace Forum.Core.Interfaces.CommentToAnswer
{
    public interface ICommentToAnswerService : IService<CommentToAnswerClass>
    {
        public IList<CommentToAnswerClass> GetListWithSpecificAnswerId(int answerId);
    }
}
