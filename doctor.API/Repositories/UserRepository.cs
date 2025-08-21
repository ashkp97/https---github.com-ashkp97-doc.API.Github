using Microsoft.EntityFrameworkCore;

public class UserRepository : RepositoryDBContext<int, User>
{
    public UserRepository(ClinicContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<User>> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async override Task<User> GetByKey(int key)
    {
        var user = await _context.Users.SingleOrDefaultAsync(d => d.UserId == key);
        return user;
    }
}