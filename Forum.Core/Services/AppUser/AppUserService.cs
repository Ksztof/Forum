using Forum.Core.Interfaces.AppUsers;
using Forum.Core.Interfaces.BaseInterface;
using Forum.Core.Repositories.AppUser;
using Forum.Domain;
using System.ComponentModel.DataAnnotations;
using AppUserClass = Forum.Domain.AppUser;


namespace Forum.Core.Services.AppUser
{
    public class AppUserService : IAppUserService
    {
        private AppUserRepository _appUserRepository = null;
        private AppUserRepository AppUserRepository
        {
            get
            {
                if (_appUserRepository == null)
                {
                    _appUserRepository = new AppUserRepository();
                }

                return _appUserRepository;
            }
        }


        private UserProfileService _UserProfileService = null;
        private UserProfileService UserProfileService
        {
            get
            {
                if (_UserProfileService == null)
                {
                    _UserProfileService = new UserProfileService();
                }

                return _UserProfileService;
            }
        }


        public AppUserClass Add(AppUserClass entity)
        {
            return AppUserRepository.Add(entity);
        }


        public IEnumerable<AppUserClass> GetList()
        {
            var appUserData = AppUserRepository.GetList();
            return appUserData;
        }


        public AppUserClass GetBy(int id)
        {
            var appUser = AppUserRepository.GetBy(id);
            var UserProfile = UserProfileService.GetBy(id);
            appUser.UserProfile = UserProfile;
            return appUser;
        }


        public AppUserClass Update(AppUserClass entity)
        {
            var updatedAppUser = AppUserRepository.Update(entity);

            return updatedAppUser;
        }


        public bool Delete(AppUserClass entity)
        {
            var deleteAppUser = AppUserRepository.Delete(entity);

            if (deleteAppUser != true)
            {
                return false;
            }
            return true;
        }


        public AppUserClass GetByEmail(string email)
        {
            if (!new EmailAddressAttribute().IsValid(email))
            {
                return null;
            }
            if (AppUserRepository.Db.AppUsers.Any(x => x.Email.ToUpper() == email.ToUpper()))
            {
                var appUser = AppUserRepository.Db.AppUsers.Where(x => x.Email.ToUpper() == email.ToUpper()).First();
                return appUser;
            }
            return null;
        }


    }
}
