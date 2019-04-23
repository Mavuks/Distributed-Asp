using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SchoolingRepository: BaseRepository<Schooling, AppDbContext>, ISchoolingRepository
    {
        public SchoolingRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        

        public async Task<List<Schooling>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(a => a.Material)
                .ToListAsync();
        }
    }    
}