using System.Threading.Tasks;
using API.Data;
using API.Interface;
using AutoMapper;

namespace API.DTOs
{
    public class UnitOfWOrk : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UnitOfWOrk(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public IUserRepository userRepository => new UserRepository(_context, _mapper);

        public IMessageRepository messageRepository => new MessageRepository(_context, _mapper);

        public ILikeRepository likeRepository => new LikesRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChange()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
