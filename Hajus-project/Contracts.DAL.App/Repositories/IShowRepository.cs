using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;
 
 namespace Contracts.DAL.App.Repositories
 {
     
     public interface IShowRepository : IShowRepository<DALAppDTO.Show>
     {
     }
     public interface IShowRepository<TDALEntity> : IBaseRepository<TDALEntity>
         where TDALEntity : class, new()
     {
         // add here custom methods
         
         Task<List<TDALEntity>> AllForUserAsync(int userId);
     }
 }