using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(c => c.Locations)
                .ThenInclude( t => t.Translations)
                .Select(c => new
                {
                    Id = c.Id,
                    Locations = c.Locations,
                    Translations = c.Locations.Translations,
                    
                })
                .ToListAsync();
            
            var resultList = res.Select(c => new  DTO.Location()
            {
                Id = c.Id,
                Locations = c.Locations.Translate(),
                
                     
            }).ToList();
            return resultList;
        }

        public override async Task<DTO.Location> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var location = await RepositoryDbSet.FindAsync(id);
            if (location != null)
            {
                await RepositoryDbContext.Entry(location)
                    .Reference(c => c.Locations)
                    .LoadAsync();
                await RepositoryDbContext.Entry(location.Locations)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
 
            return LocationMapper.MapFromDomain(location);
        }
        
        
        public override DTO.Location Update(DTO.Location entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.Locations)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.Locations.SetTranslation(entity.Locations);

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Location>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(m => m.Locations)
                .ThenInclude(t => t.Translations)
                .Include(c => c.Shows)
                .Include( i => i.Competitions )
                .Select(e => LocationMapper.MapFromDomain(e)).ToListAsync();
        }
        
    }    
}