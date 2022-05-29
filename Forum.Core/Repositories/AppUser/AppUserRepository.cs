using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Forum.Core.Repositories.AppUser
{

    public class AppUserRepository : Repository, IAppUserRepository
    {
        public Domain.AppUser Add(Domain.AppUser entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var appUser = db.AppUsers.Add(entity);
                db.SaveChanges();
                return appUser.Entity;
            }
        }


        public bool Delete(Domain.AppUser entity)
        {


            using (ForumDb db = new ForumDb())
            {
                if (!db.AppUsers.Any(x => x.Id == entity.Id))
                {
                    return false;
                }

                var appUser = db.AppUsers.Remove(entity);
                db.SaveChanges();
                return true;
            }
        }

        //Pozmieniałem to na koniec, dodałem includa
        public Domain.AppUser GetBy(int id)
        {
            using (ForumDb db = new ForumDb())
            {
                var appUser = db.AppUsers.Where(x => x.Id == id).First();
                return appUser;
            }
        }

        public IEnumerable<Domain.AppUser> GetList()
        {
            using (ForumDb db = new ForumDb())
            {
                var appUsersList = db.AppUsers.OrderBy(x => x.Username);
                return appUsersList.ToList();
            }
        }


        public Domain.AppUser Update(Domain.AppUser entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var appUser = db.AppUsers.Update(entity);
                db.SaveChanges();
                return appUser.Entity;
            }
        }
    }
}
