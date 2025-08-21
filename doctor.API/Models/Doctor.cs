using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Doctor
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    public int DepartmentId { get; set; } //ForeignKey
    //[ForeignKey("DepartmentId")] - commented for fluent API
    public Department? Department { get; set; } //Relation definition property (onedoctor - one dept - one to many)
    [Required]
    public int YearsOfExperience { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsSenior { get; set; } = false;

    public User? User { get; set; }
}