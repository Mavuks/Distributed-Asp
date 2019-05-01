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
    public class ParticipantService : BaseEntityService<BLL.App.DTO.Participant, DAL.App.DTO.Participant, IAppUnitOfWork>, IParticipantService
    {
        public ParticipantService(IAppUnitOfWork uow) : base(uow, new ParticipantMapper())
        {
        }

        public async Task<List<BLL.App.DTO.ParticipantNames>>  GetAllParticipantAsync()
        {
            return (await Uow.Participant.GetAllParticipantAsync()).Select(e => ParticipantMapper.MapFromInternal(e)).ToList();
        }
    }
}