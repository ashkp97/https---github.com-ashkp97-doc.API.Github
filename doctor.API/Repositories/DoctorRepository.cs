
public class DoctorRepository : Repository<int, Doctor>
{
    public async override Task<Doctor> GetByKey(int Key)
    {
        var doctor = items.SingleOrDefault(d => d.Id == Key);
        return doctor;
    }
}