using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class RegistrationRepository: BaseRepository<Registration>, IRegistrationRepository
    {
        public RegistrationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }    
}