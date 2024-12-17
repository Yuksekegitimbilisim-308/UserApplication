using UserApplication.Entity;

namespace UserApplication.Service.Abstract
{
    public interface IUserService
    {
        Task<bool> Login(string username,string password);
        Task<User> GetById(string username);
        Task<User> GetById(int id);
    }
}
