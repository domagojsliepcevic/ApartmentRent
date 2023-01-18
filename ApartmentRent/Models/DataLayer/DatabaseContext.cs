using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ApartmentRent.Models.DomainModels;

namespace ApartmentRent.Models
{
    public class DatabaseContext : IdentityDbContext<User>
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
       
     
        public DbSet<Apartment> Apartment {get; set; }
        public DbSet<ApartmentAlbum> ApartmentAlbum {get; set; }
        public DbSet<ApartmentOwner> ApartmentOwner { get; set; }
        public DbSet<ApartmentPicture> ApartmentPicture {get; set; }
        public DbSet<ApartmentProfilePicture> ApartmentProfilePicture { get; set; }
        public DbSet<ApartmentStatus> ApartmentStatus { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagType> TagType { get; set; }
        public DbSet<TaggedApartment> TaggedApartments { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ApartmentReview> ApartmentReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApartmentConfig());
            builder.ApplyConfiguration(new ApartmentOwnerConfig());
            builder.ApplyConfiguration(new ApartmentStatusConfig());
            builder.ApplyConfiguration(new CityConfig());
            builder.ApplyConfiguration(new TagConfig());
            builder.ApplyConfiguration(new TagTypeConfig());
            builder.ApplyConfiguration(new TaggedApartmentConfig());
            builder.ApplyConfiguration(new ApartmentAlbumConfig());
            builder.ApplyConfiguration(new ApartmentProfilePictureConfig());   

            base.OnModelCreating(builder);
        }


        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            
            string[] roleNames = { "Admin", "ApartmentOwner", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }



            string username = "admin@helpdesk.com";
            string password = "Pa$$w0rd";
            string rlName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(rlName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(rlName));
            }

            // if username doesn't exist, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, rlName);
                }
            }
        }
    }
}
