using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.Services
{
    public class LocationService : BaseEntityService<BLL.App.DTO.Location, DAL.App.DTO.Location, IAppUnitOfWork>, ILocationService
    {
        public LocationService(IAppUnitOfWork uow) : base(uow, new LocationMapper())
        {
        }



  
    }
}