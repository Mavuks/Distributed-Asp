using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
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
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var res = await RepositoryDbSet
                .Include(c => c.Breed)
                .Include( a=> a.DogName)
                .Include(s => s.Sex)
                 .Where(b => b.AppUserId == userId)
                .Select(c => new
                {
                    Id = c.Id,
                    DogName = c.DogName,
                    Breed = c.Breed,
                    Owner = c.Owner,
                    DateOfBirth = c.DateOfBirth,
                    DateOfDeath = c.DateOfDeath,
                    Sex = c.Sex,
                    Translations = c.Sex.Translations,

                })
                .ToListAsync();
            
            var resultList = res.Select(c => new  DTO.Dog()
            {
                Id = c.Id,
                DogName = c.DogName,
                //Breed = c.Breed,
                DateOfBirth = c.DateOfBirth,
                DateOfDeath = c.DateOfDeath,
                Owner = c.Owner,
                Sex = c.Sex.Translate(),
                
                     
            }).ToList();
            return resultList;
        }


        public override async Task<DTO.Dog> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var dog = await RepositoryDbSet.FindAsync(id);
            if (dog != null)
            {
                await RepositoryDbContext.Entry(dog)
                    .Reference(c => c.Sex)
                    .LoadAsync();
                await RepositoryDbContext.Entry(dog.Sex)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
 
            return DogMapper.MapFromDomain(dog);
        }
        
        
        public override DTO.Dog Update(DTO.Dog entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.DogName)
                .Include(m => m.Sex)
                .ThenInclude(t => t.Translations)
                .Include(a => a.Breed)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.Sex.SetTranslation(entity.Sex);

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Dog>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(m => m.Sex)
                
                .ThenInclude(t => t.Translations)
                .Include(a => a.Breed)
                .Include(c => c.Registrations)
                .Select(e => DogMapper.MapFromDomain(e)).ToListAsync();
        }
        
        
         }
    }