using System.Collections;
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
using BreedMapper = DAL.App.EF.Mappers.BreedMapper;

namespace DAL.App.EF.Repositories
{
    public class BreedRepository: BaseRepository<DAL.App.DTO.Breed, Domain.Breed,  AppDbContext>, IBreedRepository
    {
        public BreedRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new BreedMapper())
        {
           
        }

        public override async Task<DTO.Breed> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var breed = await RepositoryDbSet.FindAsync(id);
            if (breed != null)
            {
                await RepositoryDbContext.Entry(breed)
                    .Reference(c => c.BreedNameValue)
                    .LoadAsync();
                await RepositoryDbContext.Entry(breed.BreedNameValue)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
 
            return BreedMapper.MapFromDomain(breed);
        }
        
        
        public override DTO.Breed Update(DTO.Breed entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.BreedNameValue)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.BreedNameValue.SetTranslation(entity.BreedNameValue);

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Breed>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(m => m.BreedNameValue)
                .ThenInclude(t => t.Translations)
                .Include(c => c.Dogs)
                .Select(e => BreedMapper.MapFromDomain(e)).ToListAsync();
        }

        
        
        
        public virtual async Task<List<BreedWithDogCounts>> GetAllWithBreedCountAsync()
        {
//            return await RepositoryDbSet
//                .Select(b => new BreedWithDogCounts()
//                {
//                    Id = b.Id,
//                    BreedNameValue = b.BreedNameValue,
//                    BreedCount = b.Dogs.Count
//                    
//                    
//                }).ToListAsync();
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
        
            var res = await RepositoryDbSet
                .Include(m => m.BreedNameValue)
                .ThenInclude(t => t.Translations)
                //.Where(x => x.ContactTypeValue.Translations.Any(t => t.Culture == culture))
                .Select(c => new
                {
                    Id = c.Id,
                    BreedNameValue = c.BreedNameValue,
                    Translations = c.BreedNameValue.Translations,
                    BreedCount = c.Dogs.Count
                })
                .ToListAsync();

             
            var resultList = res.Select(c => new  BreedWithDogCounts()
            {
                Id = c.Id,
                BreedCount = c.BreedCount,
                BreedNameValue = c.BreedNameValue.Translate()
                     
            }).ToList();
            return resultList;
        }
    }    
    
}