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
    public class BreedRepository: BaseRepository<Breed>, IBreedRepository
    {
        public BreedRepository(IDataContext dataContext) : base(dataContext)
        {
           
        }

        public virtual async Task<IEnumerable<BreedDTO>> GetAllWithBreedCountAsync()
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