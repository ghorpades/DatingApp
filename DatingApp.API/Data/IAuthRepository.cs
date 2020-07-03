using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
         
         // register a user
        Task<User> Register(User user , string password);

         //login a user
        Task<User> Login(string username, string password);

         //user exist in DB 

        Task<bool> UserExist(string username);

    }
}