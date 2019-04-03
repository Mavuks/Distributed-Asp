using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
 using Domain;
 
 namespace Contracts.DAL.App.Repositories
 {
     public interface IAwardRepository : IBaseRepositoryAsync<Award>
     {
         // add here custom methods
         Task<IEnumerable<Award>> AllAsync();
     }
 }