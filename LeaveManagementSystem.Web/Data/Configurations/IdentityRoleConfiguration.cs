using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
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
        }
    }
}
