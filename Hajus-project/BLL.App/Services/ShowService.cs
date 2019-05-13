using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;
using ee.itcollege.mavuks.BLL.Base.Services;

namespace BLL.App.Services
{
    public class ShowService : BaseEntityService<BLL.App.DTO.Show, DAL.App.DTO.Show, IAppUnitOfWork>, IShowService
    {
        public ShowService(IAppUnitOfWork uow) : base(uow, new ShowMapper())
        {
            ServiceRepository = Uow.Show;
        }

        public async Task<List<BLL.App.DTO.Show>> AllForUserAsync(int userId)
        {
            return (await Uow.Show.AllForUserAsync(userId)).Select(e => ShowMapper.MapFromInternal(e)).ToList();
        }

    }
}