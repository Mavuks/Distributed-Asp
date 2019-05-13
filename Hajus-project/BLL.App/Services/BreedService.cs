using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.mavuks.BLL.Base.Services;

namespace BLL.App.Services
{
    public class BreedService : BaseEntityService<BLL.App.DTO.Breed, DAL.App.DTO.Breed, IAppUnitOfWork>, IBreedService
    {
        public BreedService(IAppUnitOfWork uow) : base(uow, new BreedMapper())
        {
            ServiceRepository = Uow.Breed;
        }

        public async Task<List<BLL.App.DTO.BreedWithDogCounts>>  GetAllWithBreedCountAsync()
        {
            return (await Uow.Breed.GetAllWithBreedCountAsync()).Select(e => BreedMapper.MapFromInternal(e)).ToList();
        }
    }
}