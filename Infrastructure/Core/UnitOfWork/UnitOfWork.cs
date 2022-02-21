using Infrastructure.Core.IRepositories;
using Infrastructure.Core.Repositories;
using Infrastructure.DataContext;
#nullable disable

namespace Infrastructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IMemberRepository _memberRepository;

        public DatabaseContext _Context { get; }

        public UnitOfWork(DatabaseContext context)
        {
            _Context = context;
        }
        public IMemberRepository Members => _memberRepository ??
                                        (_memberRepository = new MemberRepository(_Context));
    }
}
