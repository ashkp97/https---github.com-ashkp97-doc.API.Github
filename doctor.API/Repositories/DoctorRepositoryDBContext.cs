

using Microsoft.EntityFrameworkCore;

public class DoctorRepositoryDBContext : RepositoryDBContext<int, Doctor>
{
    public DoctorRepositoryDBContext(ClinicContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<Doctor>> GetAll()
    {
        var doctors = await _context.Doctors.ToListAsync();
        return doctors;
    }

    public async override Task<Doctor> GetByKey(int Key)
    {
        var doctor = await _context.Doctors.AsNoTracking().SingleOrDefaultAsync(doc => doc.Id == Key);
        return doctor;
    }

     public async override Task<Doctor> GetByName(string name)
    {
        var doctor = await _context.Doctors.AsNoTracking().SingleOrDefaultAsync(doc => doc.Name == name);
        return doctor;
    }
}