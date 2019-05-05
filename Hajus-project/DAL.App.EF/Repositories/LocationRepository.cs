using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using LocationMapper = DAL.App.EF.Mappers.LocationMapper;

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
                //.Include(a => a.AppUser)
                .Include(c => c.Locations)
                // .Where(b => b.AppUserId == userId)
                .Select(d => LocationMapper.MapFromDomain(d))
                .ToListAsync();
        }
    }    
}