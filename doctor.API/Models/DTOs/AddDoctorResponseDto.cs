public class AddDoctorResponseDto
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string DepartmnetName { get; set; } = string.Empty;
  public int YearsOfExperience { get; set; }
  public string? Phone { get; set; }
}