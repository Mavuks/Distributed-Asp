using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using SchoolingMapper = DAL.App.EF.Mappers.SchoolingMapper;

namespace DAL.App.EF.Repositories
{
    public class SchoolingRepository: BaseRepository<DAL.App.DTO.Schooling, Domain.Schooling, AppDbContext>, ISchoolingRepository
    {
        public SchoolingRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SchoolingMapper())
        {
        }
        

        public async Task<List<DAL.App.DTO.Schooling>> AllForUserAsync(int userId)
        {
            return await RepositoryDbSet
                .Include(a => a.Material)
                .Select( s => SchoolingMapper.MapFromDomain(s))
                .ToListAsync();
        }
    }    
}