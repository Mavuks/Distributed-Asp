using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DAL.App.EF.Repositories
{
    public class CompetitionRepository: BaseRepository<DAL.App.DTO.Competition, Domain.Competition,  AppDbContext>, ICompetitionRepository
    {
        public CompetitionRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new CompetitionMapper())
        {
        }

//        public override async Task<List<Competition>> AllAsync()
//        {
//            return await RepositoryDbSet
//               // .Include(a => a.Dog)
//                .Include(b => b.Location)
//              //  .Include(c => c.Participant)
//                .ToListAsync();
//        }

        public async Task<List<DAL.App.DTO.Competition>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(b => b.Location).ToListAsync();
        }


    }    
}