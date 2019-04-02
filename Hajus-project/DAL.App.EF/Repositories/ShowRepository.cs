using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ShowRepository: BaseRepository<Show>, IShowRepository
    {
        public ShowRepository(IDataContext dataContext) : base(dataContext)
        {
        }


        public override async Task<IEnumerable<Show>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(a => a.Dog)
                .Include(b => b.Location)
                .Include(c => c.Participant).ToListAsync();
        }
    }    
}