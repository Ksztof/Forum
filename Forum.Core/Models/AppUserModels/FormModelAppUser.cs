using Forum.Domain;
using System.ComponentModel.DataAnnotations;
using extAppUser = Forum.Domain.UserProfile;
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
        // public int AppUserId { get; set; }


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

        public void changeAppUserData(FormModelAppUser model, AppUser appUser)
        {
            //nadpisac 
            appUser.Username = model.Username;
            appUser.UserProfile.Surname = model.Surname;
            appUser.UserProfile.DisplayName = model.DisplayName;
        }

    }
}
