using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RegistrationRepository: BaseRepository<Registration, AppDbContext>, IRegistrationRepository
    {
        public RegistrationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

//        public override async Task<List<Registration>> AllAsync()
//        {
//            return await RepositoryDbSet
//                
//                .Include(b => b.Dog)
//                .Include(c => c.Participant)
//                .Include(d => d.Competition)
//                .Include(e => e.Show).ToListAsync();
//        }

        public async Task<List<Registration>> AllForUserAsync(int userId)
        {
            return await  RepositoryDbSet
                .Include(b => b.Dog)
                .Include(c => c.Participant)
                .Include(d => d.Competition)
                .Include(e => e.Show).ToListAsync();
                
        }
    }    
}