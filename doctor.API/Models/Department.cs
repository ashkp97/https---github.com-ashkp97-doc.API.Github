using System.ComponentModel.DataAnnotations;

public class Department
{
    //[Key] - commented for fluent API
    public int DepartmentNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Doctor>? Doctors { get; set; }//Navigation definition property - this is optional (one dept can have multiple doctors - Many to one)
}