using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LeaveManagementSystem.Data
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



            //builder.ApplyConfiguration(new LeaveRequestStatusConfiguration());
            //builder.ApplyConfiguration(new IdentityRoleConfiguration());
            //builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
            //builder.ApplyConfiguration(new ApplicationUserConfiguration());
            // all these lines can written in one line as below
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<LeaveType> LeaveTypes{ get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<LeaveRequestStatus> LeaveRequestStatuses { get; set; }
        public DbSet <LeaveRequest> LeaveRequests { get; set; }





        /*
            email: employee1@localhost.com
            firstname: Employee
            lastname: Oneeeee
            password: Employ33.

            email: alloc_test@localhost.com
            firstname: allocation
            lastname: test_user
            password: Employ33.
                                          
            email: supervisor@localhost.com
            firstname: Supervisor
            lastname: Oneeeee
            password: Sup3rvisor.


            email: admin@localhost.com
            firstname: System
            lastname: Administrator
            password: P@ssword1
                                     
        
            email: testemailui@localhost
            firstname: testemailui
            lastname: emailui
            password: P@ssword1      
        
            email: test2emailui@localhost
            firstname: test2emailui
            lastname: emailui
            password: P@ssword1        
        
            email: test3emailui@localhost
            firstname: test3emailui
            lastname: emailui
            password: P@ssword1
        
            email: test4emailui@localhost
            firstname: test4emailui
            lastname: emailui
            password: P@ssword1

            ----------

         */
    }
}
