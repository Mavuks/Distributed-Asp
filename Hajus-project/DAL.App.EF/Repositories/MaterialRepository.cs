using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.DTO;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using MaterialMapper = DAL.App.EF.Mappers.MaterialMapper;

namespace DAL.App.EF.Repositories
{
    public class MaterialRepository: BaseRepository<DAL.App.DTO.Material, Domain.Material, AppDbContext>, IMaterialRepository
    {
        public MaterialRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new MaterialMapper())
        {
        }

        
        public virtual async Task<List<MaterialCounts>> GetAllWithMaterialCountAsync()
        {
            return await RepositoryDbSet
                .Select(b => new MaterialCounts()
                {
                    Id = b.Id,
                    MaterialName = b.MaterialName,
                    MaterialCount = b.Schoolings.Count
                    
                    
                }).ToListAsync();
        }

      
    }    
}