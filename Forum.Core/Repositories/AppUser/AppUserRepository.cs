using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Interfaces.BaseInterface;
using Forum.Domain.Models;
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
        public Domain.Models.AppUser Add(Domain.Models.AppUser entity)
        {
            using (ForumDb db = new ForumDb())
            {
                var appUser = db.AppUsers.Add(entity);
                db.SaveChanges();
                return appUser.Entity;
            }
        }


        public bool Delete(Domain.Models.AppUser entity)
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
        public Domain.Models.AppUser GetBy(int id)
        {
            using (ForumDb db = new ForumDb())
            {
                var appUser = db.AppUsers.Where(x => x.Id == id).First();
                return appUser;
            }
        }

        public IEnumerable<Domain.Models.AppUser> GetList()
        {
            using (ForumDb db = new ForumDb())
            {
                var appUsersList = db.AppUsers.OrderBy(x => x.Username);
                return appUsersList.ToList();
            }
        }


        public Domain.Models.AppUser Update(Domain.Models.AppUser entity)
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
