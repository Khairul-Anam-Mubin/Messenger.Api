namespace Messenger.Api.Interfaces
{
    public interface IRepositoryItem
    {
        string Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
