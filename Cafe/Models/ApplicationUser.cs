using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
