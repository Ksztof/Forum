using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain
{
    public class UserProfile
    {
        [Key]                   // WSKAZUJEMY KLUCZ GÓWNY
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
}
