using System.Threading.Tasks;

namespace Rock.Like.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
