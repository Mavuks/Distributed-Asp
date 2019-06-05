using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.mavuks.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface  IDogRepository : IDogRepository<DALAppDTO.Dog>
    {
        // add here custom methods
       
//        Task<Dog> FindForUserAsync(int id, int userId);
//        Task<bool> BelongsToUserAsync(int id, int userId);
        Task<List<DALAppDTO.Dog>> AllForBreedAsync(int breedId);

    }

    public interface IDogRepository<TDALEntity> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllForUserAsync(int userId);
        
        Task<TDALEntity> FindForUserAsync(int id, int userId);
        Task<bool> BelongsToUserAsync(int id, int userId);
    }
}