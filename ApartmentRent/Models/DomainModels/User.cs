using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentRent.Models
{
    public class User : IdentityUser
    {
        /*UserName The username for the user.
        Password The password for the user.
        ConfirmPassword Used to confirm that the password was entered correctly.
        Email The email address for the user.
        EmailConfirmed Used to confirm that the email was entered correctly.
        PhoneNumber The phone number for the user.
        PhoneNumberConfirmed Used to confirm that the phone number was entered correctly.*/

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [NotMapped]
        public IList<string> RoleNames { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
