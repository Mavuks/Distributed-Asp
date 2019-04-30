using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using DAL.App.DTO;
using Domain;

 
 namespace BLL.App.Services
 {
     public class CompetitionService : BaseEntityService<BLL.App.DTO.Competition,DAL.App.DTO.Competition,IAppUnitOfWork>, ICompetitionService
     {
         public CompetitionService(IAppUnitOfWork uow) : base(uow, new CompetitionMapper())
         {
             ServiceRepository = Uow.Competition;
         }
 
         public async Task<List<BLL.App.DTO.Competition>> AllForUserAsync(int userId)
         {
             return (await Uow.Competition.AllForUserAsync(userId)).Select(e => CompetitionMapper.MapFromInternal(e))
                 .ToList();
         }

     }
 }