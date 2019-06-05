using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Domain;
using Domain.Identity;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using DogMapper = DAL.App.EF.Mappers.DogMapper;
using Registration = DAL.App.DTO.Registration;
using RegistrationMapper = DAL.App.EF.Mappers.RegistrationMapper;

namespace DAL.App.EF.Repositories
{
    public class RegistrationRepository: BaseRepository<DAL.App.DTO.Registration, Domain.Registration, AppDbContext>, IRegistrationRepository
    {
        public RegistrationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new RegistrationMapper())
        {
        }

        public async Task<List<DAL.App.DTO.Registration>> AllForUserAsync(int userId)
        {
            
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();


            var res = await RepositoryDbSet
                .Include(a => a.Title)
                .ThenInclude(a => a.Translations)
                .Include(a => a.Comment)
                .ThenInclude(a => a.Translations)
                .Include(a => a.Dog)
                .ThenInclude(a => a.Sex)
                .ThenInclude(a => a.Translations)
                .Include(a => a.Participant)
                .Include(a => a.Schooling)
                .ThenInclude(a => a.SchoolingName)
                .ThenInclude(a => a.Translations)
                .Include(a => a.Show)
                .ThenInclude(a => a.Title)
                .ThenInclude(a => a.Translations)
                .Include(a => a.Show)
                .ThenInclude(a => a.Comment)
                .ThenInclude(a => a.Translations)
                .Include(a => a.Competition)
                .ThenInclude(a => a.Title)
                .ThenInclude(a => a.Translations)
                .Include(a => a.Competition)
                .ThenInclude(a => a.Comment)
                .ThenInclude(a => a.Translations)
                .Include(a => a.Schooling)
                .ThenInclude(a => a.SchoolingName)
                .ThenInclude(a => a.Translations)
                .Where( a=> a.Dog.AppUserId == userId)
                .Select(e => RegistrationMapper.MapFromDomain(e))
                .ToListAsync();
//                .Select(c => new
//                {
//                    Id = c.Id,
//                    title = c.Title,
//                    comment = c.Comment,
//                    
//                    
//                    //Dog = c.Dog,
//                    Translations = c.Comment.Translations,
//                    Translations2 = c.Title.Translations,
//                    Participant = c.Participant
//
//                })
//                .ToListAsync();
//                
//                var resultList = res.Select(c => new  DTO.Registration()
//                {
//                Id = c.Id,
//                //Dog = c.Dog,
//                Title = c.title.Translate(),
//                Comment = c.comment.Translate(),
//               // Participant = c.Participant
//                
//               
////                Participant = c.Participant,
////                Dog = c.Dog
//                
//                     
//                }).ToList();
               //return resultList;
               return res;
        }

        public async Task<List<Registration>> AllForDogRegisAsync(int dogId)
        {
            return await RepositoryDbSet
                .Include(a => a.Dog)
                .Include(a => a.Comment)
                .ThenInclude(a => a.Translations)
                .Include(a => a.Title)
                .ThenInclude( e=> e.Translations)
                .Where(a => a.DogId == dogId)
                .Select(e => RegistrationMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public override async Task<DTO.Registration> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var registration = await RepositoryDbSet.FindAsync(id);
            if (registration != null)
            {
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Schooling)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Schooling)
                    .Reference(c => c.SchoolingName)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Schooling.SchoolingName)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Competition)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Competition)
                    .Reference(c => c.Title)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Competition.Title)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Competition)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Competition)
                    .Reference(c => c.Comment)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Competition.Comment)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Title)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Title)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Comment)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Comment)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Dog)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Dog)
                    .Reference(c => c.Sex)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Dog.Sex)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Participant)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Show)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Show)
                    .Reference(c => c.Title)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Show.Title)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Show)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Show)
                    .Reference(c => c.Comment)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Show.Comment)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
//                
            }
 
            return RegistrationMapper.MapFromDomain(registration);
        }
        
        
        public override DTO.Registration Update(DTO.Registration entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.Title)
                .Include( n => n.Comment)
                .ThenInclude(t => t.Translations)
                .Include( a => a.Schooling)
                .ThenInclude(a => a.SchoolingName)
                .ThenInclude( a=> a.Translations)
                .Include(a => a.Participant)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.Title.SetTranslation(entity.Title);
            entityInDb.Comment.SetTranslation(entity.Comment);

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Registration>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(a => a.Dog)
                .ThenInclude(dog => dog.Sex)
                .ThenInclude(sex => sex.Translations)
                .Include(a => a.Dog)
                .ThenInclude(a => a.AppUser)
                .Include(m => m.Title)
                .ThenInclude(t => t.Translations)
                .Include( n=> n.Comment)
                .ThenInclude(t => t.Translations)
                .Include( a => a.Schooling)
                .ThenInclude(a => a.SchoolingName)
                .ThenInclude( a=> a.Translations)
                .Include( a => a.Show)
                .ThenInclude(a => a.Title)
                .ThenInclude( a=> a.Translations)
                .Include( a => a.Show)
                .ThenInclude(a => a.Comment)
                .ThenInclude( a=> a.Translations)
                .Include(a => a.Participant)
                
                
                .Include(a => a.Competition)
                .ThenInclude(comp => comp.Comment)
                .ThenInclude(comment => comment.Translations)

                .Include(a => a.Competition)
                .ThenInclude(comp => comp.Title)
                .ThenInclude(title => title.Translations)

                
                .Select(e => RegistrationMapper.MapFromDomain(e)).ToListAsync();
        }
    }    
}