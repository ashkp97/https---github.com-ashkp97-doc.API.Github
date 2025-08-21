using AutoMapper;
public class ClinicAutoMapper : Profile
{
    public ClinicAutoMapper()
    {
        CreateMap<AddDoctorRequestDto, Doctor>();
        CreateMap<Doctor, AddDoctorRequestDto>();
        CreateMap<AddDoctorResponseDto, Doctor>();
        CreateMap<Doctor, AddDoctorResponseDto>();
        CreateMap<GetDoctorResponseDto, Doctor>();
        CreateMap<Doctor, GetDoctorResponseDto>();
        CreateMap<UpdateDoctorRequestDto, Doctor>();
        CreateMap<Doctor, UpdateDoctorRequestDto>();
        CreateMap<UpdateDoctorResponseDto, Doctor>();
        CreateMap<Doctor, UpdateDoctorResponseDto>();
    }
}