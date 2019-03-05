using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SchoolingRepository: BaseRepository<Schooling>, ISchoolingRepository
    {
        public SchoolingRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }    
}