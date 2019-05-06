using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Domain;
using Schooling = DAL.App.DTO.Schooling;

namespace BLL.App.Services
{
    public class SchoolingService : BaseEntityService<BLL.App.DTO.Schooling,DAL.App.DTO.Schooling , IAppUnitOfWork>, ISchoolingService
    {
        public SchoolingService(IAppUnitOfWork uow) : base(uow, new SchoolingMapper())
        {
            ServiceRepository = (IBaseRepository<Schooling>) Uow.Schooling;
        }

        public async Task<List<BLL.App.DTO.Schooling>> AllForUserAsync(int userId)
        {
            return (await Uow.Schooling.AllForUserAsync(userId)).Select(e => SchoolingMapper.MapFromInternal(e)).ToList();
        }
    }
}