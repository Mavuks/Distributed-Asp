using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using DAL.App.DTO;
using Domain;

namespace BLL.App.Services
{
    public class BreedService : BaseEntityService<Breed, IAppUnitOfWork>, IBreedService
    {
        public BreedService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<BreedDTO>>  GetAllWithBreedCountAsync()
        {
            return await Uow.Breed. GetAllWithBreedCountAsync();
        }
    }
}