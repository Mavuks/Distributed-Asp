using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DALAppDTO = DAL.App.DTO;
using Domain;
using ee.itcollege.mavuks.Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface IBreedRepository : IBreedRepository<DALAppDTO.Breed>
    {
        // add here custom methods
        Task<List<DALAppDTO.BreedWithDogCounts>> GetAllWithBreedCountAsync(); 
        
    }
    
    public interface IBreedRepository<TDALEntity> : IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {      
       
    }
}