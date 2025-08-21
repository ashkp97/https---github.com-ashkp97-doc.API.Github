public class LoginSP : ILoginSP
{
    private readonly ClinicContext _context;

    public LoginSP(ClinicContext context)
    {
        _context = context;
    }
    public async Task<User> ExecuteSP(int UserId)
    {
        var loginUser = (await _context.GetLoginProc(UserId)).FirstOrDefault();
        if (loginUser == null)
            throw new Exception("Invalid userid");
        return new User()
        {
            UserId = loginUser.UserId,
            Password = loginUser.Password,
            Key = loginUser.Key,
            Role = loginUser.Role
        };
    }
}