using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using Domain;
using Domain.Identity;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;


namespace DAL.App.EF.Repositories
{
    public class CompetitionRepository : BaseRepository<DAL.App.DTO.Competition, Domain.Competition, AppDbContext>,
        ICompetitionRepository
    {
        public CompetitionRepository(AppDbContext repositoryDbContext)
            : base(repositoryDbContext, new CompetitionMapper())
        {
        }


        public async Task<List<DAL.App.DTO.Competition>> AllForUserAsync(int userId)
        {
            
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res = await RepositoryDbSet
                .Include(b => b.Comment)
                .Include( a => a.Title)
                .ThenInclude( t => t.Translations)
                .Include(a => a.Start)
                .Select(c => new
                {
                    Id = c.Id,
                    Title = c.Title,
                    Comment = c.Comment,
                    Location = c.Location,
                    End = c.End,
                    Start = c.Start,
                    Translations = c.Title.Translations,
                    Translations1 = c.Comment.Translations
                }).ToListAsync();
            
            
            var resultList = res.Select(c => new  DTO.Competition()
            {
                Id = c.Id,
                Title = c.Title.Translate(),
                Comment = c.Comment.Translate(),
                Start = c.Start,
                End = c.End,
                //Location = c.Location,
                
                
                     
            }).ToList();
            return resultList;
        }    


        public override async Task<DTO.Competition> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();

            var competition = await RepositoryDbSet.FindAsync(id);
            if (competition != null)
            {
//                await RepositoryDbContext.Entry(competition)
//                    .Reference(c => c.Location)
//                    .LoadAsync();
                await RepositoryDbContext.Entry(competition)
                    .Reference(c => c.Title)
                    .LoadAsync();
                await RepositoryDbContext.Entry(competition)
                    .Reference(c => c.Comment)
                    .LoadAsync();
                await RepositoryDbContext.Entry(competition.Title)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(competition.Comment)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(competition)
                    .Reference(c => c.Location)
                    .LoadAsync();
                await RepositoryDbContext.Entry(competition.Location)
                    .Reference(c => c.Locations)
                    .LoadAsync();
            }

            return CompetitionMapper.MapFromDomain(competition);

        }
        public override DTO.Competition Update(DTO.Competition entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.Title)
                .ThenInclude(t => t.Translations)
                .Include( n => n.Comment)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.Title.SetTranslation(entity.Title);
            entityInDb.Comment.SetTranslation(entity.Comment);

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Competition>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(m => m.Title)
                .ThenInclude(t => t.Translations)
                .Include( n=> n.Comment)
                .ThenInclude(t => t.Translations)
                .Include( a=> a.Location)
                .ThenInclude(t => t.Locations)
                .ThenInclude( t => t.Translations)
                .Select(e => CompetitionMapper.MapFromDomain(e)).ToListAsync();
        }
    }
}