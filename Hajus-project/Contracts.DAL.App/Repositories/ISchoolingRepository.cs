using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.mavuks.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;
 
 namespace Contracts.DAL.App.Repositories
 {
     public interface ISchoolingRepository : ISchoolingRepository<DALAppDTO.Schooling>
     {
         
     }
     
     
     public interface ISchoolingRepository<TDALEntity> : IBaseRepositoryAsync<TDALEntity>
         where TDALEntity : class, new()
     {
         Task<List<TDALEntity>> AllForUserAsync(int userId);

     }
 }