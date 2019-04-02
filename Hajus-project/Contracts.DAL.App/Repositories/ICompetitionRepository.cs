using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface ICompetitionRepository : IBaseRepositoryAsync<Competition>
    {
        // add here custom methods
        Task<IEnumerable<Competition>> AllAsync();
    }
}