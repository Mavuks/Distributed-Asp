using System.Threading.Tasks;
using ee.itcollege.mavuks.Contracts.Base;

namespace ee.itcollege.mavuks.Contracts.BLL.Base
{
    public interface IBaseBLL : ITrackableInstance
    {
        /*
        IBaseEntityService<TEntity> BaseEntityService<TEntity>() 
            where TEntity : class, IDomainEntity, new();
        */
        
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}