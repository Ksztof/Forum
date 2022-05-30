using Forum.Core.Interfaces.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionC = Forum.Domain.Models.Question;
namespace Forum.Core.Interfaces.Question
{
    public interface IQuestionRepository : IRepository<QuestionC>
    {
    }
}
