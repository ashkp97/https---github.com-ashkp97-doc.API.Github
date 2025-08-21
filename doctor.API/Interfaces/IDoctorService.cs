public interface IDoctorService
{
    public Task<AddDoctorResponseDto> AddNewDoctor(AddDoctorRequestDto doctor);
    public Task<ICollection<GetDoctorResponseDto>> GetDoctors();

    public Task<UpdateDoctorResponseDto> UpdateDoctor(int id, UpdateDoctorRequestDto doctor);

    public Task<GetDoctorResponseDto> DeleteDoctor(int id);
    public Task<GetDoctorResponseDto> GetDoctorById(int id);
}