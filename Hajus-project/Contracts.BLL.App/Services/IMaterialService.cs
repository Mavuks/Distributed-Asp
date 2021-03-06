using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using ee.itcollege.mavuks.Contracts.BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IMaterialService :  IBaseEntityService<BLLAppDTO.Material>, IMaterialRepository<BLLAppDTO.Material>
    {
        
        /// <summary>
        /// Get all material with counts.
        /// </summary>
        /// <returns></returns>
        Task<List<BLLAppDTO.MaterialCounts>> GetAllWithMaterialCountAsync();
    }
}