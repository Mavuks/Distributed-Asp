using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
 using Domain;
 
 namespace Contracts.DAL.App.Repositories
 {
     public interface IRegistrationRepository : IBaseRepositoryAsync<Registration>
     {
         // add here custom methods
         
         Task<List<Registration>> AllForUserAsync(int userId);

     }
 }