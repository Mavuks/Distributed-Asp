using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using RegistrationMapper = DAL.App.EF.Mappers.RegistrationMapper;

namespace DAL.App.EF.Repositories
{
    public class RegistrationRepository: BaseRepository<DAL.App.DTO.Registration, Domain.Registration, AppDbContext>, IRegistrationRepository
    {
        public RegistrationRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new RegistrationMapper())
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

        public async Task<List<DAL.App.DTO.Registration>> AllForUserAsync(int userId)
        {
            return await  RepositoryDbSet
                .Include(b => b.Dog)
                .Include(c => c.Participant)
                .Include(d => d.Competition)
                .Include(e => e.Show)
                .Select(r => RegistrationMapper.MapFromDomain(r))
                .ToListAsync();
                
        }
    }    
}