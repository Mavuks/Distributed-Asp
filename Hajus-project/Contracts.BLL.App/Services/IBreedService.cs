using System.Collections.Generic;
using System.Threading.Tasks;

using Contracts.DAL.App.Repositories;
using ee.itcollege.mavuks.Contracts.BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IBreedService : IBaseEntityService<BLLAppDTO.Breed>, IBreedRepository<BLLAppDTO.Breed>
    {
        /// <summary>
        /// Get all Breed Count
        /// </summary>
        /// <returns> Get all breed objects with count.</returns>
        Task<List<BLLAppDTO.BreedWithDogCounts>> GetAllWithBreedCountAsync();
    }
}