using Forum.Domain.Models;
using System.ComponentModel.DataAnnotations;
using extAppUser = Forum.Domain.Models.UserProfile;
namespace Forum.Core.Models.AppUserModels
{
    public class FormModelAppUser // pozmieniac nazwy
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string DisplayName { get; set; }


        public AppUser Construct()
        {
            return new AppUser()
            {
                Username = Username,
                UserProfile = new extAppUser()
                {
                    Name = Username,
                    Surname = Surname,
                    DisplayName = DisplayName,
                }
            };
        }

        public AppUser changeAppUserData(AppUser appUser)
        {
            //nadpisac 
            appUser.Username = this.Username;
            appUser.UserProfile.Surname = this.Surname;
            appUser.UserProfile.DisplayName = this.DisplayName;
            appUser.UserProfile.Name = this.Username;


            return appUser;
        }

    }
}
