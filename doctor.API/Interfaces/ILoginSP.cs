public interface ILoginSP
{
    public Task<User> ExecuteSP(int UserId);
}