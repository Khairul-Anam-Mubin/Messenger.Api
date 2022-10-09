using Messenger.Api.Interfaces;
using Messenger.Api.Models;

namespace Messenger.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IDatabaseClient _databaseClient;
        public UserService(IDatabaseClient databaseClient)
        {
            _databaseClient = databaseClient;
        }
        public async Task<UserModel> CreateUserAsync(UserModel userModel)
        {
            try
            {
                var user = await _databaseClient.InsertItemAsync<UserModel>(userModel);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserModel> UpdateUserAsync(UserModel userModel)
        {
            try
            {
                var user = await _databaseClient.UpdateItemAsync<UserModel>(userModel);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteUserByIdAsync(string id)
        {
            try
            {
                await _databaseClient.DeleteItemByIdAsync<UserModel>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            try
            {
                var user = await _databaseClient.GetItemByIdAsync<UserModel>(id);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UserModel>> GetUsersAsync()
        {
            try
            {
                var users = await _databaseClient.GetItemsAsync<UserModel>();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
