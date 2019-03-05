using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ShowRepository: BaseRepository<Show>, IShowRepository
    {
        public ShowRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }    
}