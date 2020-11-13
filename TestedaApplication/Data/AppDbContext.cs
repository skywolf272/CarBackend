using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestedaApplication.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TestedaApplication.Models;

namespace TestedaApplication.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserFavs> Favourites { get; set; }


        //Не уверен что это нужно после выполнения единажды

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "F1dfb214e2",
                Name = "user",
                NormalizedName = "USER"
            });
        }

            //    builder.Entity<IdentityUser>().HasData(new IdentityUser
            //    {
            //        Id = "1Bc",
            //        UserName = "admin",
            //        NormalizedUserName = "ADMIN",
            //        Email = "ClassCarAdmin@ClassCar.com",
            //        EmailConfirmed = true,
            //        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "adminadmin"),
            //        SecurityStamp = string.Empty
            //    });
            //    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //    {
            //        RoleId = "1Ab",
            //        UserId = "1Bc"
            //    });

            //}
        }
}
