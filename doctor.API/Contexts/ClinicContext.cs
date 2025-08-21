using Microsoft.EntityFrameworkCore;

public class ClinicContext : DbContext
{
    public ClinicContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<SpLoginDto> SpLoginDto { get; set; }

    public async Task<IEnumerable<SpLoginDto>> GetLoginProc(int doctorId) => await this.Set<SpLoginDto>()
                                                            .FromSqlInterpolated($"proc_LoginGet {doctorId}")
                                                            .ToListAsync();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasKey(doc => doc.Id).HasName("PK_Doctor");
        modelBuilder.Entity<Department>().HasKey(dept => dept.DepartmentNumber).HasName("PK_Department");
        modelBuilder.Entity<Doctor>().HasOne(doc => doc.Department)
                                    .WithMany(dept => dept.Doctors)
                                    .HasForeignKey(doc => doc.DepartmentId)
                                    .HasConstraintName("FK_Doctor_Department")
                                    .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<User>().HasKey(usr => usr.UserId).HasName("PK_User");
        modelBuilder.Entity<User>().HasOne(usr => usr.Doctor).WithOne(doc => doc.User)
                                    .HasForeignKey<User>(u => u.UserId)
                                    .HasConstraintName("FK_Employee_User")
                                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentNumber = 101, Name = "Orthopedics" },
            new Department { DepartmentNumber = 102, Name = "Pediatrics" },
            new Department { DepartmentNumber = 103, Name = "General Medicine" },
            new Department { DepartmentNumber = 104, Name = "Neurology" }
        );
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { Id = 100, Name = "Ashfak", DepartmentId = 101, YearsOfExperience = 10, PhoneNumber = "1234567890" },
            new Doctor { Id = 101, Name = "Pranay", DepartmentId = 102, YearsOfExperience = 10, PhoneNumber = "0987654321" }
        );
    }
}