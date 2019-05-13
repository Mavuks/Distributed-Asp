using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Helpers;
using DAL.App.EF.Mappers;
using Domain.Identity;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;


namespace DAL.App.EF.Repositories
{
    public class CompetitionRepository: BaseRepository<DAL.App.DTO.Competition, Domain.Competition,  AppDbContext>, ICompetitionRepository
    {
        public CompetitionRepository(AppDbContext repositoryDbContext) 
            : base(repositoryDbContext, new CompetitionMapper())
        {
        }


        public async Task<List<DAL.App.DTO.Competition>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(b => b.Location)
                .Select(c => CompetitionMapper.MapFromDomain(c))
                .ToListAsync();
        }


    }    
}