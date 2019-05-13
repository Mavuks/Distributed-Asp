using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.mavuks.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;
 
 namespace Contracts.DAL.App.Repositories
 {
     
     public interface ILocationRepository : ILocationRepository<DALAppDTO.Location>
     {
     }
     public interface ILocationRepository<TDALEntity> : IBaseRepository<TDALEntity>
         where TDALEntity : class, new()
     {
         Task<List<TDALEntity>> AllForUserAsync(int userId);
     }
 }