using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Domain;

namespace BLL.App.Services
{
    public class RegistrationService : BaseEntityService<Registration, IAppUnitOfWork>, IRegistrationService
    {
        public RegistrationService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<List<Registration>> AllForUserAsync(int userId)
        {
            return await Uow.Registration.AllForUserAsync(userId);
        }

        }
    }
