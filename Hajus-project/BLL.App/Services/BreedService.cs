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