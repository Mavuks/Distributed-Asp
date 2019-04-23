using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class MaterialRepository: BaseRepository<Material, AppDbContext>, IMaterialRepository
    {
        public MaterialRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        
        public virtual async Task<List<MaterialDTO>> GetAllWithMaterialCountAsync()
        {
            return await RepositoryDbSet
                .Select(b => new MaterialDTO()
                {
                    Id = b.Id,
                    MaterialName = b.MaterialName,
                    MaterialCount = b.Schoolings.Count
                    
                    
                }).ToListAsync();
        }

      
    }    
}