using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using Domain;
using ee.itcollege.mavuks.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using BreedMapper = DAL.App.EF.Mappers.BreedMapper;

namespace DAL.App.EF.Repositories
{
    public class BreedRepository: BaseRepository<DAL.App.DTO.Breed, Domain.Breed,  AppDbContext>, IBreedRepository
    {
        public BreedRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new BreedMapper())
        {
           
        }

        public virtual async Task<List<BreedWithDogCounts>> GetAllWithBreedCountAsync()
        {
            return await RepositoryDbSet
                .Select(b => new BreedWithDogCounts()
                {
                    Id = b.Id,
                    BreedName = b.BreedName,
                    BreedCount = b.Dogs.Count
                    
                    
                }).ToListAsync();
        }
    }    
    
}