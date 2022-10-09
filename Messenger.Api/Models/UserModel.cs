using Messenger.Api.Interfaces;

namespace Messenger.Api.Models
{
    public class UserModel : IRepositoryItem
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public UserModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
