using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ParticipantRepository: BaseRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }    
}