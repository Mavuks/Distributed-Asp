using ee.itcollege.mavuks.Contracts.Base;
using ee.itcollege.mavuks.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.mavuks.Contracts.BLL.Base.Services
{
    public interface IBaseService : ITrackableInstance
    {
    }
    
    public interface IBaseEntityService<TBLLEntity> :IBaseService, IBaseRepository<TBLLEntity> 
        where TBLLEntity : class, new()
    {
        
    }
    
    
    
    
}