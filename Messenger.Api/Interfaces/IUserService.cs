using Messenger.Api.Models;

namespace Messenger.Api.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> CreateUserAsync(UserModel userModel);
        Task<UserModel> UpdateUserAsync(UserModel userModel);
        Task DeleteUserByIdAsync(string id);
        Task<UserModel> GetUserByIdAsync(string id);
        Task<List<UserModel>> GetUsersAsync();
    }
}
