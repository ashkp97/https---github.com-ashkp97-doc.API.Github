public class GetDoctorResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public int YearsOfExperience { get; set; }
    public string? Phone { get; set; }
    public string Seniority { get; set; } = string.Empty;
}