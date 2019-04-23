using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.Services
{
    public class SchoolingService : BaseEntityService<Schooling, IAppUnitOfWork>, ISchoolingService
    {
        public SchoolingService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<Schooling>> AllForUserAsync(int userId)
        {
            return await Uow.Schooling.AllForUserAsync(userId);
        }
    }
}