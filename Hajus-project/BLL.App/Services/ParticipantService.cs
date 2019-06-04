using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.DTO;
using Domain;
using ee.itcollege.mavuks.BLL.Base.Services;

namespace BLL.App.Services
{
    public class ParticipantService : BaseEntityService<BLL.App.DTO.Participant, DAL.App.DTO.Participant, IAppUnitOfWork>, IParticipantService
    {
        public ParticipantService(IAppUnitOfWork uow) : base(uow, new ParticipantMapper())
        {
            ServiceRepository = Uow.Participant;
        }
        
        public async Task<List<BLL.App.DTO.Participant>> AllForUserAsync(int userId)
        {
            return (await Uow.Participant.AllForUserAsync(userId)).Select(e => ParticipantMapper.MapFromInternal(e)).ToList();
        }
//

        public async Task<List<BLL.App.DTO.ParticipantNames>>  GetAllParticipantAsync()
        {
            return (await Uow.Participant.GetAllParticipantAsync()).Select(e => ParticipantMapper.MapFromInternal(e)).ToList();
        }
    }
}