using System.Threading.Tasks;
using ee.itcollege.mavuks.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.mavuks.Contracts.DAL.Base
{
    public interface IBaseUnitOfWork
    {
        IBaseRepository<TDALEntity> BaseRepository<TDALEntity, TDomainEntity>()
            where TDomainEntity : class, IDomainEntity, new()
            where TDALEntity : class, new();
        
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}