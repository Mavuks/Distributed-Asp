using System.Collections;
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
    public class ParticipantRepository : BaseRepository<Participant, AppDbContext>, IParticipantRepository
    {
        

        public ParticipantRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }


        

        public virtual async Task<List<ParticipantDTO>> GetAllParticipantAsync()
        {
            return await RepositoryDbSet
                .Select(p => new ParticipantDTO()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName

                }).ToListAsync();
        }
    }
}