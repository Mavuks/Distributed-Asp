using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.DTO;
using Domain;
using ee.itcollege.mavuks.BLL.Base.Services;
using Competition = BLL.App.DTO.Competition;


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

         public async Task<List<Competition>> AllForCompLocationAsync(int locationId)
         {
             return (await Uow.Competition.AllForCompLocationAsync(locationId))
                 .Select(e => CompetitionMapper.MapFromInternal(e)).ToList();
         }
     }
 }