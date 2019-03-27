using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SchoolingRepository: BaseRepository<Schooling>, ISchoolingRepository
    {
        public SchoolingRepository(IDataContext dataContext) : base(dataContext)
        {
        }
        
        public override async Task<IEnumerable<Schooling>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(a => a.Material)
                .Include(b => b.Dog).ToListAsync();
        }
    }    
}