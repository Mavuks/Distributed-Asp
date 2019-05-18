using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using Domain;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Material = Domain.Material;
using MaterialMapper = DAL.App.EF.Mappers.MaterialMapper;

namespace DAL.App.EF.Repositories
{
    public class MaterialRepository: BaseRepository<DAL.App.DTO.Material, Domain.Material, AppDbContext>, IMaterialRepository
    {
        public MaterialRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MaterialMapper())
        {
        }

        
        public override async Task<DTO.Material> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var material = await RepositoryDbSet.FindAsync(id);
            if (material != null)
            {
                await RepositoryDbContext.Entry(material)
                    .Reference(c => c.MaterialName)
                    .LoadAsync();
                await RepositoryDbContext.Entry(material.MaterialName)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
 
            return MaterialMapper.MapFromDomain(material);
        }
        
        
        public override DTO.Material Update(DTO.Material entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.MaterialName)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.MaterialName.SetTranslation(entity.MaterialName);

            return entity;
        }
        
        
        
        public override async Task<List<DAL.App.DTO.Material>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(m => m.MaterialName)
                .ThenInclude(t => t.Translations)
                .Include(c => c.Schoolings)
                .Select(e => MaterialMapper.MapFromDomain(e)).ToListAsync();
        }
        public virtual async Task<List<MaterialCounts>> GetAllWithMaterialCountAsync()
        {

            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
        
            var res = await RepositoryDbSet
                .Include(m => m.MaterialName)
                .ThenInclude(t => t.Translations)
                //.Where(x => x.ContactTypeValue.Translations.Any(t => t.Culture == culture))
                .Select(c => new
                {
                    Id = c.Id,
                    MaterialName = c.MaterialName,
                    Translations = c.MaterialName.Translations,
                    MaterialCounts = c.Schoolings.Count
                })
                .ToListAsync();

             
            var resultList = res.Select(c => new  MaterialCounts()
            {
                Id = c.Id,
                MaterialCount = c.MaterialCounts,
                MaterialName = c.MaterialName.Translate()
                     
            }).ToList();
            return resultList;
        }
        
        
        
    }    
}