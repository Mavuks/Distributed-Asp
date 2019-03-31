using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RegistrationRepository: BaseRepository<Registration>, IRegistrationRepository
    {
        public RegistrationRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Registration>> AllAsync()
        {
            return await RepositoryDbSet
                
                .Include(b => b.Dog)
                .Include(c => c.Participant)
                .Include(d => d.Competition)
                .Include(e => e.Show).ToListAsync();
        }
    }    
}