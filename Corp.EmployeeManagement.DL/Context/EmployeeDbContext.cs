using System;
using Microsoft.EntityFrameworkCore;
namespace Corp.EmployeeManagement.DL.Context
{
     public class EmployeeDbContext : DbContext  
    {  
        public EmployeeDbContext() : base()  
        {  
        }  
        public EmployeeDbContext(DbContextOptions options) : base(options)  
        {  
        }  
  
        public DbSet<Employee> Employees { get; set; }  

           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=BLACKBOX\BP_LC1;Database=Employees;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("EmployeeID")
               .UseIdentityColumn(1,1);

                entity.Property(e => e.Name).HasColumnName("EmployeeName")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired(true);

                entity.Property(e=>e.Contact).HasColumnName("Contact")
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsRequired(true);

                entity.Property(entity=>entity.BloodGroup).HasColumnName("BloodGroup")
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsRequired(true);
                 
            });

             
        }
    }
}
