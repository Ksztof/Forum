using Forum.Core.Interfaces.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswerC = Forum.Domain.Answer;
namespace Forum.Core.Interfaces.Answer
{
    public interface IAnswerService : IService<AnswerC>
    {
    }
}
