using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAnswer = Forum.Domain.Models.Answer;
using Forum.Core.Interfaces.BaseInterface;

namespace Forum.Core.Interfaces.Answer
{
    public interface IAnswerRepository : IRepository<DomainAnswer>
    {
        
    }

}
