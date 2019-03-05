using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BreedRepository: BaseRepository<Breed>, IBreedRepository
    {
        public BreedRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }    
}