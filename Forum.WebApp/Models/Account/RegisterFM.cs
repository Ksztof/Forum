using Forum.Domain.Models;
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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public AppUser ContructAppUser()
        {
            return new AppUser()
            {
                Username = this.UserName,
                Email = this.Email,
                UserProfile = new UserProfile()
                {
                    Name = this.Name,
                    Surname = this.Surname,
                    DisplayName = this.UserName,
                }
            };
        }
        

    }
}
