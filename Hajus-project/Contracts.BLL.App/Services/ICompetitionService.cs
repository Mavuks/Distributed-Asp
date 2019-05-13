using Contracts.DAL.App.Repositories;
using ee.itcollege.mavuks.Contracts.BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface ICompetitionService : IBaseEntityService<BLLAppDTO.Competition>, ICompetitionRepository<BLLAppDTO.Competition>
    {
        
    }
}