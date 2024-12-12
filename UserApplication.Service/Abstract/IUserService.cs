namespace UserApplication.Service.Abstract
{
    public interface IUserService
    {
        Task<bool> Login(string username,string password);
    }
}
