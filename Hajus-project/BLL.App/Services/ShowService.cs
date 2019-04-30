using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.Services
{
    public class ShowService : BaseEntityService<BLL.App.DTO.Show, DAL.App.DTO.Show, IAppUnitOfWork>, IShowService
    {
        public ShowService(IAppUnitOfWork uow) : base(uow, new ShowMapper())
        {
        }

        public async Task<List<BLL.App.DTO.Show>> AllForUserAsync(int userId)
        {
            return (await Uow.Show.AllForUserAsync(userId)).Select(e => ShowMapper.MapFromInternal(e)).ToList();
        }

    }
}