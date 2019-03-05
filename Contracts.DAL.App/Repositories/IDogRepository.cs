using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IDogRepository : IBaseRepository<Dog>
    {
        // add here custom methods
        Task<IEnumerable<Dog>> AllAsync(int userId);
    }
}