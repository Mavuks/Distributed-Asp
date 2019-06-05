using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Breed = DAL.App.DTO.Breed;
using Dog = DAL.App.DTO.Dog;
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

            var resultList = await RepositoryDbSet
                .Include(a => a.Breed)
                .ThenInclude(a => a.BreedName)
                .ThenInclude( a=> a.Translations)
                .Include(a => a.AppUser)
                .Include(a => a.Sex)
                .ThenInclude(a => a.Translations)
                .Where(p => p.AppUserId == userId)
                .Select(c => DogMapper.MapFromDomain(c))
                .ToListAsync();








//           var resultList = await RepositoryDbSet
//                .Include(a=> a.Breed)
//                .ThenInclude( a=> a.BreedName)
//                .ThenInclude( a=> a.Translations)
//                .Include(a => a.Sex)
//                .ThenInclude( a=> a.Translations)
//                .Include( a=> a.Owner)
//                .Include( a=> a.DateOfBirth)
//                
//                
//                .Where( a=> a.AppUserId == userId)
//                .Select(c => DogMapper.MapFromDomain(c))
//                .ToListAsync();
//            
//            var res = await RepositoryDbSet
//                .Where(b => b.AppUserId == userId)
//                .Select(c => new
//                {
//                    Id = c.Id,
//                    DogName = c.DogName,
//                    Breed = c.Breed,
//                    Owner = c.Owner,
//                    DateOfBirth = c.DateOfBirth,
//                    DateOfDeath = c.DateOfDeath,
//                    Sex = c.Sex,
//                    Translations = c.Sex.Translations,
//
//                })
//                .ToListAsync();
//            
//            var resultList = res.Select(c => new  DTO.Dog()
//            {
//                Id = c.Id,
//                DogName = c.DogName,
//               // Breed = c.Breed,
//                DateOfBirth = c.DateOfBirth,
//                DateOfDeath = c.DateOfDeath,
//                Owner = c.Owner,
//                Sex = c.Sex.Translate(),
//                
//                     
//            }).ToList();
            return resultList;
        }

        public async Task<Dog> FindForUserAsync(int id, int userId)
        {
            return DogMapper.MapFromDomain(await RepositoryDbSet
                .Include( a=> a.Breed)
                .ThenInclude( a=> a.BreedName)
                .ThenInclude(a=> a.Translations)
                .Include(a=> a.Sex)
                .ThenInclude(a => a.Translations)
                .Include(p => p.AppUser)
                .FirstOrDefaultAsync(p => p.Id == id && p.AppUserId == userId));
        }

        public async Task<bool> BelongsToUserAsync(int id, int userId)
        {
            return await RepositoryDbSet.AnyAsync(p => p.Id == id && p.AppUserId == userId);
        }

        public async Task<List<DAL.App.DTO.Dog>> AllForBreedAsync(int breedId)
        {
            return await RepositoryDbSet
                .Include(a => a.Breed)
                .Include(a => a.Sex)
                .ThenInclude(a => a.Translations)
                .Where(a => a.BreedId == breedId)
                .Select(e => DogMapper.MapFromDomain(e))
                .ToListAsync();
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
                await RepositoryDbContext.Entry(dog)
                    .Reference(c => c.Breed)
                    .LoadAsync();
                await RepositoryDbContext.Entry(dog.Breed)
                    .Reference(c => c.BreedName)
                    .LoadAsync();
                await RepositoryDbContext.Entry(dog.Breed.BreedName)
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
                .Include(m => m.Sex)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.Sex.SetTranslation(entity.Sex);

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Dog>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(a => a.AppUser)
                .Include(m => m.Sex)
                .ThenInclude(t => t.Translations)
                .Include(a => a.Breed)
                .ThenInclude( a => a.BreedName)
                .ThenInclude( t => t.Translations)
                .Select(e => DogMapper.MapFromDomain(e)).ToListAsync();
        }
        
        
         }
    }