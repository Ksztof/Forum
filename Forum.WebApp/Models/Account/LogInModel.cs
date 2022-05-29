using System.ComponentModel.DataAnnotations;

namespace Forum.WebApp.Models.Account
{
    public class LogInModel
    {
        [Required]
        public string AccountUserLogin { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string AccountUserPassword { get; set; }  
    }
}
