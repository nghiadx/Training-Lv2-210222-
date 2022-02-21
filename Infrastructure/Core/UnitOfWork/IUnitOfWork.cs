using Infrastructure.Core.IRepositories;
using Infrastructure.DataContext;

namespace Infrastructure.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMemberRepository Members { get; }
        DatabaseContext _Context { get; }
    }
}
