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
using RegistrationMapper = DAL.App.EF.Mappers.RegistrationMapper;

namespace DAL.App.EF.Repositories
{
    public class RegistrationRepository: BaseRepository<DAL.App.DTO.Registration, Domain.Registration, AppDbContext>, IRegistrationRepository
    {
        public RegistrationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new RegistrationMapper())
        {
        }

//        public override async Task<List<Registration>> AllAsync()
//        {
//            return await RepositoryDbSet
//                
//                .Include(b => b.Dog)
//                .Include(c => c.Participant)
//                .Include(d => d.Competition)
//                .Include(e => e.Show).ToListAsync();
//        }

        public async Task<List<DAL.App.DTO.Registration>> AllForUserAsync(int userId)
        {
            
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await  RepositoryDbSet
                .Include(c => c.Participant)
                .Include(d => d.Competition)
                .Include(e => e.Show)
                .Select(c => new
                {
                    Id = c.Id,
                    title = c.Title,
                    comment = c.Comment,
                    Dog = c.Dog,
                    Translations = c.Comment.Translations,
                    Translations2 = c.Title.Translations,
                    Participant = c.Participant

                })
                .ToListAsync();
                
                var resultList = res.Select(c => new  DTO.Registration()
                {
                Id = c.Id,
                Title = c.title.Translate(),
                Comment = c.comment.Translate(),
               
//                Participant = c.Participant,
//                Dog = c.Dog
                
                     
                }).ToList();
                return resultList;
        }
        
        public override async Task<DTO.Registration> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var registration = await RepositoryDbSet.FindAsync(id);
            if (registration != null)
            {
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Title)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration)
                    .Reference(c => c.Comment)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Title)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(registration.Comment)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
 
            return RegistrationMapper.MapFromDomain(registration);
        }
        
        
        public override DTO.Registration Update(DTO.Registration entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.Title)
                .Include( n => n.Comment)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.Title.SetTranslation(entity.Title);
            entityInDb.Comment.SetTranslation(entity.Comment);

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Registration>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(m => m.Title)
                .Include( n=> n.Comment)
                .ThenInclude(t => t.Translations)
                .Include(c => c.Participant)
                .Include(a=> a. Dog)
                .Include(t => t.Show)
                .Include( e => e.Competition)
                .Select(e => RegistrationMapper.MapFromDomain(e)).ToListAsync();
        }
    }    
}