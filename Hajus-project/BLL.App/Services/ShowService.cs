using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.Services
{
    public class ShowService : BaseEntityService<Show, IAppUnitOfWork>, IShowService
    {
        public ShowService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<Show>> AllForUserAsync(int userId)
        {
            return await Uow.Show.AllForUserAsync(userId);
        }

    }
}