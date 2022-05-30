using Forum.Core.Interfaces.Answer;
using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Repositories.Answer
{
    public class AnswerRepository : Repository, IAnswerRepository
    {
        public Domain.Models.Answer Add(Domain.Models.Answer entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var answer = db.Answers.Add(entity);
                db.SaveChanges();
                return answer.Entity;
            }
        }


        public bool Delete(Domain.Models.Answer entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var answer = db.Answers.Remove(entity);
                db.SaveChanges();
                return true;
            }
        }

        public Domain.Models.Answer GetBy(int id)
        {
            using (ForumDb db = new ForumDb())
            {
                var answer = db.Answers.Where(x => x.Id == id).First();
                return answer;
            }
        }

        public IEnumerable<Domain.Models.Answer> GetList()
        {
            using (ForumDb db = new ForumDb())
            {
                /*                var appUsersList = db.AppUsers.OrderBy(x => x.Username);
                */
                var answersList = db.Answers.OrderBy(x => x.AppUserId);
                return answersList.ToList();
            }
        }


        public Domain.Models.Answer Update(Domain.Models.Answer entity)
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
