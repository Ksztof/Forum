using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentToAnswerClass = Forum.Domain.CommentToAnswer;
namespace Forum.Core.Interfaces.CommentToAnswer
{
    public interface ICommentToAnswerService : IService<CommentToAnswerClass>
    {
        public IList<CommentToAnswerClass> GetListWithSpecificAnswerId(int answerId);
    }
}
