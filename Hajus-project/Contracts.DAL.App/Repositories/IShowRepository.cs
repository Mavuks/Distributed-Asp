using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
 using Domain;
 
 namespace Contracts.DAL.App.Repositories
 {
     public interface IShowRepository : IBaseRepositoryAsync<Show>
     {
         // add here custom methods
         
         Task<List<Show>> AllForUserAsync(int userId);
     }
 }