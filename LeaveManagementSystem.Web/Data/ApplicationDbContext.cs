using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                    { 
                        Id = "6cf65df1-597c-447e-9e47-208ae83f4aea",
                        Name = "Employee",
                        NormalizedName = "EMPLOYEE"
                    },
                    new IdentityRole
                    {
                        Id = "7e336a5a-3f08-4d8c-986e-17e6d5233b90",
                        Name = "Supervisor",
                        NormalizedName = "SUPERVISOR"
                    },
                    new IdentityRole
                    { 
                        Id = "c2909634-c00e-4491-b6ac-1de88f7eeef1",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    }
                );

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    { 
                        Id = "297d438f-7cf3-4f90-84a9-8598959e95bb",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "ADMIN@LOCALHOST.COM",
                        NormalizedUserName = "ADMIN@LOCALHOST.COM",
                        UserName = "admin@localhost.com",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                        EmailConfirmed = true,
                        FirstName = "System",
                        LastName = "Administrator",
                        DateOfBirth = new DateOnly(1990, 1, 1)
                    }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    { 
                        RoleId = "c2909634-c00e-4491-b6ac-1de88f7eeef1",
                        UserId = "297d438f-7cf3-4f90-84a9-8598959e95bb"
                    }
                );
        }

        public DbSet<LeaveType> LeaveTypes{ get; set; }
    }
}
