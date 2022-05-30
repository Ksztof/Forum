using Forum.Core.Interfaces.Answer;
using Forum.Core.Repositories.Answer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswerClass = Forum.Domain.Models.Answer;
namespace Forum.Core.Services.Answer
{
    public class AnswerService : IAnswerService
    {
        private AnswerRepository _answerRepository = null;
        private AnswerRepository answerRepository
        {
            get
            {
                if (_answerRepository == null)
                {
                    _answerRepository = new AnswerRepository();
                }
                return _answerRepository;
            }
        }



        public AnswerClass Add(AnswerClass entity)
        {
            return answerRepository.Add(entity);
        }

        public bool Delete(AnswerClass entity)
        {
            return answerRepository.Delete(entity);
        }

        public AnswerClass GetBy(int id)
        {
            return answerRepository.GetBy(id);
        }

        public IEnumerable<AnswerClass> GetList()
        {
            return answerRepository.GetList();
        }

        public AnswerClass Update(AnswerClass entity)
        {
            return answerRepository.Update(entity);
        }

        
    }
}
