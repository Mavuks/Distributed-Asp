using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AwardRepository: BaseRepository<Award>, IAwardRepository
    {
        public AwardRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Award>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(a => a.Competition)
                .Include(b => b.Show).ToListAsync();

        }
    }    
}