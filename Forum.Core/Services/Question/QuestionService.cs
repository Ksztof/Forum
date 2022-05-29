using Forum.Core.Interfaces.BaseInterface;
using Forum.Core.Interfaces.Question;
using Forum.Core.Repositories.Question;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionC = Forum.Domain.Question;

namespace Forum.Core.Services.Question
{
    public class QuestionService : IQuestionService
    {
        private QuestionRepository _questionRepository;
        private QuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository == null)
                {
                    _questionRepository = new QuestionRepository();
                }
                return _questionRepository;
            }
        }
        
        public QuestionC Add(QuestionC entity)
        {
            return QuestionRepository.Add(entity);
        }

        public bool Delete(QuestionC entity)
        {
            return QuestionRepository.Delete(entity);
        }

        public QuestionC GetBy(int id)
        {
            return QuestionRepository.GetBy(id);
        }

        public IEnumerable<QuestionC> GetList()
        {
            return QuestionRepository.GetList();
        }

        public QuestionC Update(QuestionC entity)
        {
            return QuestionRepository.Update(entity);
        }
    }
}
