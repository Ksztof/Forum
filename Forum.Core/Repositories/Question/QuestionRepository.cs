using Forum.Core.Interfaces.BaseInterface;
using Forum.Core.Interfaces.Question;
using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionC = Forum.Domain.Question;
namespace Forum.Core.Repositories.Question
{
    public class QuestionRepository : Repository, IQuestionRepository
    {
        public QuestionC Add(QuestionC entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var question = db.Questions.Add(entity);
                db.SaveChanges();
                return question.Entity;
            }
        }


        public bool Delete(QuestionC entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var question = db.Questions.Remove(entity);
                db.SaveChanges();
                return true;
            }
        }

        public QuestionC GetBy(int id)
        {
            using (ForumDb db = new ForumDb())
            {
                var question = db.Questions.Where(x => x.Id == id).First();
                return question;
            }
        }

        public IEnumerable<QuestionC> GetList()
        {
            using (ForumDb db = new ForumDb())
            {
                var questionsList = db.Questions.OrderBy(x => x.AppUser);
                return questionsList.ToList();
            }
        }



        public Domain.Question Update(Domain.Question entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var question = db.Questions.Update(entity);
                db.SaveChanges();
                return question.Entity;
            }
        }
    }
}
