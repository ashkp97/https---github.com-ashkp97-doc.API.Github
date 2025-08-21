

using Microsoft.EntityFrameworkCore;

public class DepartmentRepository : RepositoryDBContext<int, Department>
{
    public DepartmentRepository(ClinicContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<Department>> GetAll()
    {
        var departments = await _context.Departments.ToListAsync();
        return departments;
    }

    public async override Task<Department> GetByKey(int Key)
    {
        var dept = await _context.Departments.SingleOrDefaultAsync(doc => doc.DepartmentNumber == Key);
        return dept;
    }
}