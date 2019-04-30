using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;
 
 namespace Contracts.DAL.App.Repositories
 {
     public interface IRegistrationRepository : IRegistrationRepository<DALAppDTO.Registration>
     {
         
     }
     
     
     public interface IRegistrationRepository<TDALEntity> : IBaseRepositoryAsync<TDALEntity>
         where TDALEntity : class, new()
     {
         // add here custom methods
         
         Task<List<TDALEntity>> AllForUserAsync(int userId);

     }
 }