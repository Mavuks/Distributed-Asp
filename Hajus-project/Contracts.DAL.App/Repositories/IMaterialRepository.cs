using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using Domain;
 
 namespace Contracts.DAL.App.Repositories
 {
     public interface IMaterialRepository : IBaseRepositoryAsync<Material, int>
     {
         // add here custom methods
         
         Task<List<MaterialDTO>> GetAllWithMaterialCountAsync();
     }
 }