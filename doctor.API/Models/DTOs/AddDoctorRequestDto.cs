public class AddDoctorRequestDto
{
    public string Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public int YearsOfExperience { get; set; }
    public string? Phone { get; set; }

}