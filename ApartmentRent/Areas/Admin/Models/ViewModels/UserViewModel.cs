using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ApartmentRent.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IList<string> RoleNames { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
