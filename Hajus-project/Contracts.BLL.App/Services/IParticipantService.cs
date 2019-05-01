using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using System.Collections.Generic;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IParticipantService : IBaseEntityService<BLLAppDTO.Participant>, IParticipantRepository<BLLAppDTO.Participant>
    {

        Task<List<BLLAppDTO.ParticipantNames>> GetAllParticipantAsync();
    }
}