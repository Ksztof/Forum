using Forum.Domain;
using System.ComponentModel.DataAnnotations;

namespace Forum.WebApp.Models.Account
{
    public class RegisterFM
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirm { get; set; }
        [Required]
        public string Email { get; set; }

        public AppUser ContructAppUser()
        {
            return new AppUser()
            {
                Username = this.UserName,
                Email = this.Email,
            };
        }


    }
}
