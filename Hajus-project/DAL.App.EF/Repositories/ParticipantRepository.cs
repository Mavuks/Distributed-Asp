using System.Collections;
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
using ParticipantMapper = DAL.App.EF.Mappers.ParticipantMapper;

namespace DAL.App.EF.Repositories
{
    public class ParticipantRepository : BaseRepository<DAL.App.DTO.Participant, Domain.Participant, AppDbContext>, IParticipantRepository
    {
        

        public ParticipantRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new ParticipantMapper())
        {
        }


        

        public virtual async Task<List<ParticipantNames>> GetAllParticipantAsync()
        {
            return await RepositoryDbSet
                .Select(p => new ParticipantNames()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName

                }).ToListAsync();
        }
    }
}