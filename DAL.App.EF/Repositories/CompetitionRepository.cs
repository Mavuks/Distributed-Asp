using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompetitionRepository: BaseRepository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }    
}