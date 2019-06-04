using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.mavuks.BLL.Base.Services;
using Dog = BLL.App.DTO.Dog;

namespace BLL.App.Services
{
    public class DogService : BaseEntityService<BLL.App.DTO.Dog, DAL.App.DTO.Dog,  IAppUnitOfWork>, IDogService
    {
        public DogService(IAppUnitOfWork uow) : base(uow, new DogMapper())
        {
            ServiceRepository = Uow.Dog;
        }

        public async Task<List<BLL.App.DTO.Dog>> AllForUserAsync(int userId)
        {
            return (await Uow.Dog.AllForUserAsync(userId)).Select(e => DogMapper.MapFromInternal(e)).ToList();
        }

        public async Task<List<Dog>> AllForBreedAsync(int breedId)
        {
            return (await Uow.Dog.AllForBreedAsync(breedId))
                .Select(e => DogMapper.MapFromInternal(e)).ToList();
        }
//
//        public async Task<Dog> FindForUserAsync(int id, int userId)
//        {
//            return await Uow.Dog.FindForUserAsync(id, userId);
//        }
//
//        public async Task<bool> BelongsToUserAsync(int id, int userId)
//        {
//            return await Uow.Dog.BelongsToUserAsync(id, userId);
//        }

    }
}