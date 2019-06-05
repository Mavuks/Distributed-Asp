using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using ee.itcollege.mavuks.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ICompetitionRepository : ICompetitionRepository<DALAppDTO.Competition>
    {
        Task<List<DALAppDTO.Competition>> AllForCompLocationAsync(int locationId);
    }

    public interface ICompetitionRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        // add here custom methods
        Task<List<TDALEntity>> AllForUserAsync(int userId);
    }
}