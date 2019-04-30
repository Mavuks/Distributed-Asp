using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using DAL.App.DTO;
using Domain;

namespace BLL.App.Services
{
    public class MaterialService : BaseEntityService<BLL.App.DTO.Material, DAL.App.DTO.Material, IAppUnitOfWork>, IMaterialService
    {
        public MaterialService(IAppUnitOfWork uow) : base(uow, new MaterialMapper())
        {
        }

        public async Task<List<BLL.App.DTO.MaterialCounts>>  GetAllWithMaterialCountAsync()
        {
            return (await Uow.Material. GetAllWithMaterialCountAsync()).Select(e => MaterialMapper.MapFromInternal(e)).ToList();
        }
    }
}