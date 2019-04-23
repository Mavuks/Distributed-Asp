using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DogRepository:BaseRepository<Dog, AppDbContext>, IDogRepository
    {
        public DogRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }


        public async Task<List<Dog>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                //.Include(a => a.AppUser)
                .Include(c => c.Breed)
                // .Where(b => b.AppUserId == userId)
                .ToListAsync();
        }
    }
}