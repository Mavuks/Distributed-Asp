using System.Collections.Generic;
using System.Threading.Tasks;

using Contracts.DAL.App.Repositories;
using ee.itcollege.mavuks.Contracts.BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IParticipantService : IBaseEntityService<BLLAppDTO.Participant>, IParticipantRepository<BLLAppDTO.Participant>
    {

        Task<List<BLLAppDTO.ParticipantNames>> GetAllParticipantAsync();
    }
}