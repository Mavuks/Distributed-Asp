using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DAL.App.EF.Repositories
{
    public class CompetitionRepository: BaseRepository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Competition>> AllAsync()
        {
            return await RepositoryDbSet
               // .Include(a => a.Dog)
                .Include(b => b.Location)
              //  .Include(c => c.Participant)
                .ToListAsync();
        }
    }    
}