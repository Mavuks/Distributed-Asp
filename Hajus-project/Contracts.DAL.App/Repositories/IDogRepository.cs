using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface  IDogRepository : IBaseRepository<Dog>
    {
        // add here custom methods
        Task<List<Dog>> AllForUserAsync(int userId);
//        Task<Dog> FindForUserAsync(int id, int userId);
//        Task<bool> BelongsToUserAsync(int id, int userId);

    }
}