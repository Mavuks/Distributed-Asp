using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ICompetitionRepository : ICompetitionRepository<DALAppDTO.Competition>
    {

    }

    public interface ICompetitionRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        // add here custom methods
        Task<List<TDALEntity>> AllForUserAsync(int userId);
    }
}