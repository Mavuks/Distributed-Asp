using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using SchoolingMapper = DAL.App.EF.Mappers.SchoolingMapper;

namespace DAL.App.EF.Repositories
{
    public class SchoolingRepository: BaseRepository<DAL.App.DTO.Schooling, Domain.Schooling, AppDbContext>, ISchoolingRepository
    {
        public SchoolingRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SchoolingMapper())
        {
        }
        

        public async Task<List<DAL.App.DTO.Schooling>> AllForUserAsync(int userId)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res =  await RepositoryDbSet
                .Include(a => a.Material)
                .ThenInclude( a=> a.MaterialName)
                .Select(c => new
                {
                    Id = c.Id,
                    Start = c.Start,
                    End = c.End,
                    
                    SchoolingName = c.SchoolingName,
                    Translations = c.SchoolingName.Translations,
                    

                })
                .ToListAsync();
            
            var resultList = res.Select(c => new  DTO.Schooling()
            {
                Id = c.Id,
                SchoolingName = c.SchoolingName.Translate(),
                
                Start = c.Start,
                End = c.End,
                
                
                     
            }).ToList();
            return resultList;
        }
        
        
        public override async Task<DTO.Schooling> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var schooling = await RepositoryDbSet.FindAsync(id);
            if (schooling != null)
            {
                await RepositoryDbContext.Entry(schooling)
                    .Reference(c => c.SchoolingName)
                    .LoadAsync();
                await RepositoryDbContext.Entry(schooling)
                    .Reference(c => c.Material)
                    .LoadAsync();
                await RepositoryDbContext.Entry(schooling.SchoolingName)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
 
            return SchoolingMapper.MapFromDomain(schooling);
        }
        
        
        public override DTO.Schooling Update(DTO.Schooling entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(a => a.Material)
                .ThenInclude(a => a.MaterialName)
                .Include( a=> a.Start)
                .Include(a => a.End)
                .Include(m => m.SchoolingName)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.SchoolingName.SetTranslation(entity.SchoolingName);

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Schooling>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(m => m.SchoolingName)
                
                .ThenInclude(t => t.Translations)
                .Include(c => c.Material)
                .ThenInclude( a=> a.MaterialName)
                .Include(a => a.End)
                .Include(a => a.Start)
                .Select(e => SchoolingMapper.MapFromDomain(e)).ToListAsync();
        }
    }    
}