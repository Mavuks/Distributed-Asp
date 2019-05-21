using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using ShowMapper = DAL.App.EF.Mappers.ShowMapper;

namespace DAL.App.EF.Repositories
{
    public class ShowRepository: BaseRepository<DAL.App.DTO.Show, Domain.Show, AppDbContext>, IShowRepository
    {
        public ShowRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new ShowMapper())
        {
        }


        public async Task<List<DAL.App.DTO.Show>> AllForUserAsync(int userId)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var res =  await RepositoryDbSet
                .Select(c => new
                {
                    Id = c.Id,
                    Title = c.Title,
                    Start = c.Start,
                    End = c.End,
                    Translations = c.Title.Translations,
                    Comment = c.Comment,
                    Translations2 = c.Comment.Translations,

                })
                .ToListAsync();
            
            var resultList = res.Select(c => new  DTO.Show()
            {
                Id = c.Id,
                Title = c.Title.Translate(),
                Comment = c.Comment.Translate(),
                Start = c.Start,
                End = c.End,
                
                     
            }).ToList();
            return resultList;
        }
        
        
        public override async Task<DTO.Show> FindAsync(params object[] id)
        {
            var culture = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLower();
            
            var show = await RepositoryDbSet.FindAsync(id);
            if (show != null)
            {
                await RepositoryDbContext.Entry(show)
                    .Reference(c => c.Title)
                    .LoadAsync();
                await RepositoryDbContext.Entry(show)
                    .Reference(c => c.Location)
                    .LoadAsync();
                
                await RepositoryDbContext.Entry(show)
                    .Reference(c => c.Comment)
                    .LoadAsync();
                await RepositoryDbContext.Entry(show.Title)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
                await RepositoryDbContext.Entry(show.Comment)
                    .Collection(b => b.Translations)
                    .Query()
                    .Where(t => t.Culture == culture)
                    .LoadAsync();
            }
 
            return ShowMapper.MapFromDomain(show);
        }
        
        
        public override DTO.Show Update(DTO.Show entity)
        {
            var entityInDb = RepositoryDbSet
                .Include(m => m.Title)
                .Include( a=> a.Start)
                .Include( a => a.End)
                .Include( a=> a.Location)
                .Include( n => n.Comment)
                .ThenInclude(t => t.Translations)
                .FirstOrDefault(x => x.Id == entity.Id);
            
            entityInDb.Title.SetTranslation(entity.Title);
            entityInDb.Comment.SetTranslation(entity.Comment);
            

            return entity;
        }
        
        public override async Task<List<DAL.App.DTO.Show>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(m => m.Title)
                .Include(a => a.Start)
                .Include( a => a.End)
                .Include( n=> n.Comment)
                .ThenInclude(t => t.Translations)
                .Include(c => c.Location)
               
                .Select(e => ShowMapper.MapFromDomain(e)).ToListAsync();
        }
    }    
}