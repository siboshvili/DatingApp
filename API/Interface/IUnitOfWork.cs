using System.Threading.Tasks;

namespace API.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository userRepository { get; }
        IMessageRepository messageRepository { get; }
        ILikeRepository likeRepository { get; }
        Task<bool> Complete();
        bool HasChange();
    }
}
