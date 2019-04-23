using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class BreedRepository: BaseRepository<Breed, AppDbContext>, IBreedRepository
    {
        public BreedRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
           
        }

        public virtual async Task<List<BreedDTO>> GetAllWithBreedCountAsync()
        {
            return await RepositoryDbSet
                .Select(b => new BreedDTO()
                {
                    Id = b.Id,
                    BreedName = b.BreedName,
                    BreedCount = b.Dogs.Count
                    
                    
                }).ToListAsync();
        }
    }    
    
}