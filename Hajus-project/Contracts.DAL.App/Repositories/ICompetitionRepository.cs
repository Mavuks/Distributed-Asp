using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ICompetitionRepository : IBaseRepository<Competition>
    {
        // add here custom methods
        Task<List<Competition>> AllForUserAsync(int userId);
    }
}