using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using Domain;
using Registration = DAL.App.DTO.Registration;

namespace BLL.App.Services
{
    public class RegistrationService : BaseEntityService<BLL.App.DTO.Registration, DAL.App.DTO.Registration, IAppUnitOfWork>, IRegistrationService
    {
        public RegistrationService(IAppUnitOfWork uow) : base(uow, new RegistrationMapper())
        {
           ServiceRepository = (IBaseRepository<Registration>) Uow.Registration;
        }

        public async Task<List<BLL.App.DTO.Registration>> AllForUserAsync(int userId)
        {
            return (await Uow.Registration.AllForUserAsync(userId)).Select(e => RegistrationMapper.MapFromInternal(e)).ToList();
        }

        }
    }
