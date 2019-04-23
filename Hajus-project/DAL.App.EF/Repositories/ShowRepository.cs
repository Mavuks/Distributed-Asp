using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ShowRepository: BaseRepository<Show, AppDbContext>, IShowRepository
    {
        public ShowRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }


        public async Task<List<Show>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(b => b.Location)
                .ToListAsync();
        }
    }    
}