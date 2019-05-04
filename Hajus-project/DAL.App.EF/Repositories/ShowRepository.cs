using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using ShowMapper = DAL.App.EF.Mappers.ShowMapper;

namespace DAL.App.EF.Repositories
{
    public class ShowRepository: BaseRepository<DAL.App.DTO.Show, Domain.Show, AppDbContext>, IShowRepository
    {
        public ShowRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new ShowMapper())
        {
        }


        public async Task<List<DAL.App.DTO.Show>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(b => b.Location)
                .Select(s => ShowMapper.MapFromDomain(s))
                .ToListAsync();
        }
    }    
}