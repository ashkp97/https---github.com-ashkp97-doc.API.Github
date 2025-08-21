>dotnet add package Microsoft.EntityFrameworkCore --version 9.0.8
>dotnet add package Microsoft.EntityFrameworkCore.SqlServer
>dotnet add package Microsoft.EntityFrameworkCore.Design

>dotnet ef migrations add <CustomNameOfMigration>
>dotnet ef database update

----------------------------------------------------------
Attribute method :- 

public class Department
{
    [Key] 
    public int DepartmentNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Doctor>? Doctors { get; set; }//Navigation definition property - this is optional (one dept can have multiple doctors - Many to one)
}

public class Doctor
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public int DepartmentId { get; set; } //ForeignKey
    [ForeignKey("DepartmentId")] 
    public Department? Department { get; set; } //Relation definition property (onedoctor - one dept - one to many)
    [Required]
    public int YearsOfExperience { get; set; }
    public string? PhoneNumber { get; set; }
}

public DbSet<Doctor> Doctors { get; set; }
public DbSet<Department> Departments { get; set; }

--------------------------------------------------------------
Fluent APi - used in the code
------------------------------------------------------------
DB first aproach - https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/crud?view=aspnetcore-9.0