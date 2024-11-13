using Microsoft.EntityFrameworkCore;

namespace Paygenix.Models
{
    public class PayGenixDB:DbContext
    {
        public PayGenixDB()
        {

        }
        public PayGenixDB(DbContextOptions<PayGenixDB> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-I52SSPFA\\SQLEXPRESS;Database=PayGenix;" + "Trusted_Connection=True;Integrated Security= True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Payroll> Payrolls { get; set; }

        public DbSet<Benefit> Benefits { get; set; }

        public DbSet<ComplainceReport> ComplainceReports { get; set; }

        public DbSet<EmployeeBenefit> EmployeeBenefits { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DbSet<Role> Role { get; set; }

    }
}
