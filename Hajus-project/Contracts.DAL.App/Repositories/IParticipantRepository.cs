using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using Domain;
 
 namespace Contracts.DAL.App.Repositories
 {
     public interface IParticipantRepository : IBaseRepositoryAsync<Participant>
     {
         // add here custom methods
         Task<IEnumerable<ParticipantDTO>> GetAllParticipantAsync();
     }
 }