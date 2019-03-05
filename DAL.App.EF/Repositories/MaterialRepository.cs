using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MaterialRepository: BaseRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }    
}