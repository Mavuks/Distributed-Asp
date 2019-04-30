using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;
 
 namespace Contracts.DAL.App.Repositories
 {
     public interface IMaterialRepository : IMaterialRepository<DALAppDTO.Material>
     {
         // add here custom methods
         
         Task<List<DALAppDTO.MaterialCounts>> GetAllWithMaterialCountAsync();
     }
     
     public interface IMaterialRepository<TDALEntity> : IBaseRepository<TDALEntity> 
         where TDALEntity : class, new()
     {      
        
     }
 }