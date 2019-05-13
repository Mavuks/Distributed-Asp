using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using DogMapper = DAL.App.EF.Mappers.DogMapper;

namespace DAL.App.EF.Repositories
{
    public class DogRepository : BaseRepository<DAL.App.DTO.Dog, Domain.Dog, AppDbContext>,
        IDogRepository
    {
        public DogRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new DogMapper())
        {
        }


        public async Task<List<DAL.App.DTO.Dog>> AllForUserAsync(int userId)
             {
                 return await RepositoryDbSet
                     //.Include(a => a.AppUser)
                     .Include(c => c.Breed)
                     // .Where(b => b.AppUserId == userId)
                     .Select(d => DogMapper.MapFromDomain(d))
                     .ToListAsync();
             }
         }
}