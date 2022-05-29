using Forum.Core.Interfaces.Answer;
using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Repositories.Answer
{
    public class AnswerRepository : Repository, IAnswerRepository
    {
        public Domain.Answer Add(Domain.Answer entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var answer = db.Answers.Add(entity);
                db.SaveChanges();
                return answer.Entity;
            }
        }


        public bool Delete(Domain.Answer entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var answer = db.Answers.Remove(entity);
                db.SaveChanges();
                return true;
            }
        }

        public Domain.Answer GetBy(int id)
        {
            using (ForumDb db = new ForumDb())
            {
                var answer = db.Answers.Where(x => x.Id == id).First();
                return answer;
            }
        }

        public IEnumerable<Domain.Answer> GetList()
        {
            using (ForumDb db = new ForumDb())
            {
                /*                var appUsersList = db.AppUsers.OrderBy(x => x.Username);
                */
                var answersList = db.Answers.OrderBy(x => x.AppUserId);
                return answersList.ToList();
            }
        }


        public Domain.Answer Update(Domain.Answer entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var answer = db.Answers.Update(entity);
                db.SaveChanges();
                return answer.Entity;
            }
        }


    }
}
