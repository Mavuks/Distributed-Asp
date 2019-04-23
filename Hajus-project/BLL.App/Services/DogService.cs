using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.Services
{
    public class DogService : BaseEntityService<Dog, IAppUnitOfWork>, IDogService
    {
        public DogService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<Dog>> AllForUserAsync(int userId)
        {
            return await Uow.Dog.AllAsync();
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