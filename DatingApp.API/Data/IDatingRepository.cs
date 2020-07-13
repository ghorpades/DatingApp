using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    //query the data base to reterive the database. Interface in c# 
    public interface IDatingRepository
    {
         void Add<T>(T entity) where T: class;  // This method <T> is a generic method T is type of user or photo
         void Delete<T>(T entity) where T: class;  // Generic method of type T ,where T can be a user or photo
         Task<bool> SaveAll();

         Task<IEnumerable<User>> GetUsers();  // This will help us to get the users

         Task<User> GetUser(int id);

    }
}