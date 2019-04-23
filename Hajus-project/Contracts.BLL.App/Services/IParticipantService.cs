using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;

namespace Contracts.BLL.App.Services
{
    public interface IParticipantService : IBaseEntityService<Participant>, IParticipantRepository
    {
    }
}