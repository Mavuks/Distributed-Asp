using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IBreedRepository : IBaseRepositoryAsync<Breed, int>
    {
        // add here custom methods
        Task<IEnumerable<BreedDTO>> GetAllWithBreedCountAsync();
    }
}