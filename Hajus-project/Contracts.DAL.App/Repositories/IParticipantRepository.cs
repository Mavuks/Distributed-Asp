using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;
using Domain;
 
 namespace Contracts.DAL.App.Repositories
 {
     
     public interface IParticipantRepository : IParticipantRepository<DALAppDTO.Participant>
     {
                  
        
         // add here custom methods
         Task<List<DALAppDTO.ParticipantNames>> GetAllParticipantAsync();
     }
     
     public interface IParticipantRepository<TDALEntity> : IBaseRepository<TDALEntity>
         where TDALEntity : class, new()
     {

     }


 }