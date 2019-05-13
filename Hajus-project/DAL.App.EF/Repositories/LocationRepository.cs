using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using Domain.Identity;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class LocationRepository: BaseRepository<DAL.App.DTO.Location, Domain.Location, AppDbContext>,
        ILocationRepository
    {
        public LocationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new LocationMapper())
        {
        }

        public async Task<List<DAL.App.DTO.Location>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(c => c.Locations)
                .Select(d => LocationMapper.MapFromDomain(d))
                .ToListAsync();
        }
    }    
}