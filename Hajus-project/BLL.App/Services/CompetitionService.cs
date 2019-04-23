using System.Collections.Generic;
 using System.Threading.Tasks;
 using BLL.Base.Services;
 using Contracts.BLL.App.Services;
 using Contracts.DAL.App;
 using Contracts.DAL.Base;
 using Domain;
 
 namespace BLL.App.Services
 {
     public class CompetitionService : BaseEntityService<Competition, IAppUnitOfWork>, ICompetitionService
     {
         public CompetitionService(IAppUnitOfWork uow) : base(uow)
         {
         }
 
         public async Task<List<Competition>> AllForUserAsync(int userId)
         {
             return await Uow.Competition.AllForUserAsync(userId);
         }

     }
 }