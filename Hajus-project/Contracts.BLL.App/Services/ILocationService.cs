using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using ee.itcollege.mavuks.Contracts.BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface ILocationService : IBaseEntityService<BLLAppDTO.Location>, ILocationRepository<BLLAppDTO.Location>
    {
    }
}