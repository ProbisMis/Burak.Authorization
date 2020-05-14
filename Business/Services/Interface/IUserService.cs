using Burak.Authorization.Data.EntityModels;
using Burak.Authorization.Models.Requests;
using Burak.Authorization.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burak.Authorization.Business.Services.Implementation
{
    public interface IUserService
    {
        //Authentication
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();

        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> GetUserById(int userId);
        Task<User> DeleteUser(User user);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmail(string email);
    }
}
