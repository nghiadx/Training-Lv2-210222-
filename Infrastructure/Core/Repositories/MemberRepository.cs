using Infrastructure.Core.Infrastructures;
using Infrastructure.Core.IRepositories;
using Infrastructure.DataContext;
using Infrastructure.Models.Entities;

namespace Infrastructure.Core.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public DatabaseContext DatabaseContext => _context;
        public MemberRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
