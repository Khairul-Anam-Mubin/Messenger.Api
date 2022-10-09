using Messenger.Api.Interfaces;

namespace Messenger.Api.Models
{
    public class FriendModel : IRepositoryItem
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string FriendId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
